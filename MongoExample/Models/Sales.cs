using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace MongoExample.Models {
    public class Sales {
        [BsonId]
        [BsonRepresentation(BsonType.Int64)]
        public int? Id { get; set; }
        //public string? id { get; set; }
        public string item { get; set; } = null!;
        public decimal price { get; set; } = 0;
        public int quantity { get; set; } = 0;
        public DateTime date { get; set; } = new DateTime(0001,01,01);
        //public string UserName { get; set; } = null!;
        //[BsonElement("items")]
        //[JsonPropertyName("items")]
        //public List<int> SalesIds { get; set; } = null!;
    } 
}
