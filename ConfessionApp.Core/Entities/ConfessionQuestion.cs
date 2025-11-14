using MongoDB.Bson.Serialization.Attributes;

namespace ConfessionApp.Core.Entities
{
    [BsonIgnoreExtraElements]
    public class ConfessionQuestion
    {
        [BsonElement("id")]
        public int Id { get; set; }
        
        [BsonElement("prompt")]
        public string Prompt { get; set; } = string.Empty;

        [BsonElement("options")]
        public List<ConfessionOption> Options { get; set; } = new();
    }
}