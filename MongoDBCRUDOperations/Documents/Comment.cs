using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2.Documents
{
    public sealed class Comment
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
        [BsonElement("movie_id")]
        public string MovieId { get; set; } = string.Empty;
        [BsonElement("text")]
        public string Text { get; set; } = string.Empty;
        [BsonElement("date")]
        public DateTime Date { get; set; } = DateTime.MinValue;
    }
}
