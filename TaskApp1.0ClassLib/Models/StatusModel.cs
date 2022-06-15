using MongoDB.Bson.Serialization.Attributes;

namespace TaskApp1._0ClassLib.Models
{
    public class StatusModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string StatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
    }
}
