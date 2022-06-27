using MongoDB.Driver;
using TaskApp1._0ClassLib.Models;

namespace TaskApp1._0ClassLib.DataAccess.Interfaces
{
    public interface IDbConnection
    {
        IMongoCollection<CatogeoryModel> CategoryCollection { get; }
        string CategoryCollectionName { get; }
        MongoClient client { get; }
        string DBname { get; }
        IMongoCollection<StatusModel> StatusCollection { get; }
        string StatusCollectionname { get; }

       
        IMongoCollection<UserModel> UserCollection { get; }

        IMongoCollection<SuggestionModel> SuggestionCollection { get; }
        string SuggestionCollectionname { get; }

        string UserCollectionname { get; }
    }
}