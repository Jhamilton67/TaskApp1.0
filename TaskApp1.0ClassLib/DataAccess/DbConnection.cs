using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TaskApp1._0ClassLib.DataAccess.Interfaces;
using TaskApp1._0ClassLib.Models;

namespace TaskApp1._0ClassLib.DataAccess
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration _Config;
        private readonly IMongoDatabase _db;
        private string _connectionID = "MogoDB";

        public string DBname { get; private set; }
        public string CategoryCollectionName { get; private set; } = "Categories";
        public string StatusCollectionname { get; private set; } = "Status";
        public string UserCollectionname { get; private set; } = "Users";
        public string SuggestionCollectionname { get; private set; } = "Suggestions";

        public MongoClient client { get; private set; }
        public IMongoCollection<CatogeoryModel> CategoryCollection { get; private set; }
        public IMongoCollection<StatusModel> StatusCollection { get; private set; }
        public IMongoCollection<UserModel> UserCollection { get; private set; }
        public IMongoCollection<SuggestionModel> SuggestionCollection { get; private set; }

        public DbConnection(IConfiguration Config)
        {
            _Config = Config;
            client = new MongoClient(_Config.GetConnectionString(_connectionID));
            DBname = _Config["DatabaseName"];
            _db = client.GetDatabase(DBname);

            CategoryCollection = _db.GetCollection<CatogeoryModel>(CategoryCollectionName);
            StatusCollection = _db.GetCollection<StatusModel>(StatusCollectionname);
            UserCollection = _db.GetCollection<UserModel>(UserCollectionname);
            SuggestionCollection = _db.GetCollection<SuggestionModel>(SuggestionCollectionname);

        }


    }
}
