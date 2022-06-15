using MongoDB.Bson.Serialization.Attributes;

namespace TaskApp1._0ClassLib.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ID { get; set; }
        public string ObjectID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public List<SuggestionModel> GetAuthoredSuggestionModels { get; set; } = new List<SuggestionModel>();
        public List<SuggestionModel> VotedOnSuggestions { get; set; } = new List<SuggestionModel>();
    }
}
