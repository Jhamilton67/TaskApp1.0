using MongoDB.Bson.Serialization.Attributes;

namespace TaskApp1._0ClassLib.Models
{
    public class SuggestionModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string SuggestionID { get; set; }
        public string SuggestionName { get; set; }
        public string SuggestionDescription { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public BasicUserModel Author { get; set; }
        public string OwnersNotes { get; set; }
        public HashSet<string> UserVotes { get; set; } = new();

        public bool ApprovedForRelease { get; set; } = false;
        public bool Archived { get; set; } = false;
        public bool Rejected { get; set; } = false;


        #region DataModels
        public CatogeoryModel GetCatogeoryModel { get; set; }
        public StatusModel GetStatusModel { get; set; }

        #endregion




    }
}
