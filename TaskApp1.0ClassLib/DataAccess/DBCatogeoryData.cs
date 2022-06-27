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
    public class DBCatogeoryData : IDBCatogeoryData
    {
        private readonly IMongoCollection<CatogeoryModel> collection;
        private readonly IMemoryCache memory;
        private const string CacheName = "CategoryName";

        public DBCatogeoryData(IDbConnection db, IMemoryCache cache)
        {
            memory = cache;
            collection = db.CategoryCollection;
        }

        public async Task<List<CatogeoryModel>> GetAllCatogeory()
        {
            var output = memory.Get<List<CatogeoryModel>>(CacheName);
            if (output == null)
            {
                var results = await collection.FindAsync(_ => true);
                output = results.ToList();

                memory.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;

        }

        public Task CreateCategory(CatogeoryModel catogeory)
        {
            return collection.InsertOneAsync(catogeory);
        }


    }
}
