using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp1._0ClassLib.DataAccess.Interfaces;
using TaskApp1._0ClassLib.Models;
using IDbConnection = TaskApp1._0ClassLib.DataAccess.Interfaces.IDbConnection;

namespace TaskApp1._0ClassLib.DataAccess
{
    public class DbSuggestionData : IDbSuggestionData
    {
        private readonly IDbConnection _db;
        private readonly IDBUserData _userdata;
        private readonly IMemoryCache _cache;
        private readonly IMongoCollection<SuggestionModel> _suggestions;
        private readonly SuggestionModel suggestion;
        private const string CacheName = "SuggestionData";



        public DbSuggestionData(IDbConnection db, IDBUserData userdata, IMemoryCache cache)
        {
            _db = db;
            _userdata = userdata;
            _cache = cache;
            _suggestions = db.SuggestionCollection;
        }

        public async Task<List<SuggestionModel>> GetAllSuggestions()
        {
            var output = _cache.Get<List<SuggestionModel>>(CacheName);
            if (output is null)
            {
                var results = await _suggestions.FindAsync(s => s.Archived == false);
                output = results.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
            }
            return output;
        }

        public async Task<List<SuggestionModel>> GetAllApprovedSuggestions()
        {
            var output = await GetAllSuggestions();
            return output.Where(x => x.ApprovedForRelease).ToList();
        }

        public async Task<SuggestionModel> GetSuggestion(string id)
        {
            var results = await _suggestions.FindAsync(s => s.SuggestionID == id);
            return results.FirstOrDefault();
        }

        public async Task<List<SuggestionModel>> GetAllSuggestionsWaitingForApproval()
        {
            var output = await GetAllSuggestions();
            return output.Where(X => X.ApprovedForRelease == false && X.Rejected == false).ToList();
        }

        public async Task UpdateSuggestion(SuggestionModel suggestion)
        {
            await _suggestions.ReplaceOneAsync(S => S.SuggestionID == suggestion.SuggestionID, suggestion);
            _cache.Remove(CacheName);
        }

        public async Task UpvoteSuggestion(string SuggestionId, string userId)
        {
            var client = _db.client;

            using var session = await client.StartSessionAsync();

            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(_db.DBname);
                var suggestionInTransaction = db.GetCollection<SuggestionModel>(_db.SuggestionCollectionname);
                var suggetion = (await suggestionInTransaction.FindAsync(S => S.SuggestionID == SuggestionId)).First();

                bool IsUpVote = suggetion.UserVotes.Add(userId);
                if (IsUpVote == false)
                {
                    suggetion.UserVotes.Remove(userId);
                }

                await suggestionInTransaction.ReplaceOneAsync(S => S.SuggestionID == SuggestionId, suggestion);

                var UsersInTransaction = db.GetCollection<UserModel>(_db.UserCollectionname);
                var user = await _userdata.GetUser(suggetion.Author.ID);

                // TODO need to fix the BasicSuggestionModel if else statement
                if (IsUpVote)
                {
                    user.VotedOnSuggestions.Add(new BasicSuggestionModel(suggestion));
                }
                else
                {
                    var SuggestionToRemove = user.VotedOnSuggestions.Where(S => S.SuggestionID == SuggestionId).First();
                    user.VotedOnSuggestions.Remove(new BasicSuggestionModel(suggestion));
                }
                await UsersInTransaction.ReplaceOneAsync(U => U.ID == userId, user);

                await session.CommitTransactionAsync();

                _cache.Remove(CacheName);

            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }

        }

        public async Task CreateSuggestion(SuggestionModel suggestion)
        {
            var client = _db.client;

            using var session = await client.StartSessionAsync();

            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(_db.DBname);
                var suggestionInTransaction = db.GetCollection<SuggestionModel>(_db.SuggestionCollectionname);
                await suggestionInTransaction.InsertOneAsync(suggestion);

                var UserInTransaction = db.GetCollection<UserModel>(_db.UserCollectionname);
                var user = await _userdata.GetUser(suggestion.Author.ID);
                await UserInTransaction.ReplaceOneAsync(U => U.ID == user.ID, user);

                await session.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }


            return;
        }










    }
}
