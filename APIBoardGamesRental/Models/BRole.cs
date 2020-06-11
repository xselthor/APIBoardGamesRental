using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoardGamesRental.Models
{
    public class BRole
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string oid { get; set; }
        public string[] role { get; set; }
    }
}
