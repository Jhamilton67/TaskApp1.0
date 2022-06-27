using MongoDB.Bson.Serialization.Attributes;

namespace TaskApp1._0ClassLib.Models
{
    public class BasicSuggestionModel
    {

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ID { get; set; }
        public string Title { get; set; }

        public BasicSuggestionModel()
        {

        }

        public BasicSuggestionModel(SuggestionModel suggestion)
        {
            ID = suggestion.SuggestionID;
            Title = suggestion.SuggestionDescription;

        }

    }
}
