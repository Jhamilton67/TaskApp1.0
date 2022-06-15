using MongoDB.Bson.Serialization.Attributes;

namespace TaskApp1._0ClassLib.Models
{
    public class CatogeoryModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }



    }
}
