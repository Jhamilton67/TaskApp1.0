using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp1._0ClassLib.Models
{
    public  class BasicUserModel
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ID { get; set; }
        public string DisplayName { get; set; }

        public BasicUserModel()
        {

        }

        public BasicUserModel(UserModel user)
        {
            ID = user.ID;
            DisplayName = user.DisplayName;
        }
    }
}
