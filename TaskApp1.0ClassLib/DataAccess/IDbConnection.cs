using MongoDB.Driver;
using TaskApp1._0ClassLib.Models;

namespace TaskApp1._0ClassLib.DataAccess
{
    public interface IDbConnection
    {
        IMongoCollection<CatogeoryModel> CategoryCollection { get; }
        string CategoryCollectionName { get; }
        MongoClient client { get; }
        string DBname { get; }
        IMongoCollection<StatusModel> StatusCollection { get; }
        string StatusCollectionname { get; }
        IMongoCollection<SuggestionModel> SuggestionCollection { get; }
        string SuggestionCollectionname { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionname { get; }
    }
}