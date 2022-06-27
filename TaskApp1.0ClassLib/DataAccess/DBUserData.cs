using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp1._0ClassLib.DataAccess.Interfaces;
using TaskApp1._0ClassLib.Models;

namespace TaskApp1._0ClassLib.DataAccess
{
    public class DBUserData : IDBUserData
    {
        private readonly IMongoCollection<UserModel> mongoCollection;


        public DBUserData(IDbConnection db)
        {
            mongoCollection = db.UserCollection();
        }

        public async Task<List<UserModel>> GetUserAsync()
        {
            var results = await mongoCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<UserModel> GetUser(string id)
        {
            var result = await mongoCollection.FindAsync(u => u.ID == id);
            return result.FirstOrDefault();
        }

        public async Task<UserModel> GetUsefromAuthentication(string objectid)
        {
            var result = await mongoCollection.FindAsync(u => u.ObjectID == objectid);
            return result.FirstOrDefault();
        }

        public Task CreateUser(UserModel user)
        {
            return mongoCollection.InsertOneAsync(user);
        }

        public Task UpdateUser(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq("ID", user.ID);
            return mongoCollection.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }

    }
}
