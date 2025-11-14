using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConfessionApp.Core.Entities
{
    [BsonIgnoreExtraElements]
    public class Questionnaire
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)] 
        public string MongoDbId { get; set; } = string.Empty; 
    
        [BsonElement("id")]
        public int Id { get; set; } 
        
        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;
        
        [BsonElement("subtitle")]
        public string? Subtitle { get; set; }
        
        [BsonElement("questions")]
        public List<ConfessionQuestion> Questions { get; set; } = new();
    }
}