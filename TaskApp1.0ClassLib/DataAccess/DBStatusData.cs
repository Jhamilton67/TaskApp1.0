using Microsoft.Extensions.Caching.Memory;
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
    public class DBStatusData : IDBStatusData
    {
        private readonly IMongoCollection<StatusModel> _statuses;
        private readonly IMemoryCache _memoryCache;
        private const string CacheName = "StatusData";

        public DBStatusData(IDbConnection db, IMemoryCache cache)
        {
            _memoryCache = cache;
            _statuses = db.StatusCollection;

        }

        public async Task<List<StatusModel>> GetAllStatuses()
        {
            var output = _memoryCache.Get<List<StatusModel>>(CacheName);
            if (output is null)
            {
                var results = await _statuses.FindAsync(_ => true);
                output = results.ToList();

                _memoryCache.Set(CacheName, output, TimeSpan.FromDays(1));
            }

            return output;
        }

        public Task CreateStatus(StatusModel status)
        {
            return _statuses.InsertOneAsync(status);
        }
    }
}
