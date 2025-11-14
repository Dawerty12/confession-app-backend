using MongoDB.Bson.Serialization.Attributes;

namespace ConfessionApp.Core.Entities
{
    [BsonIgnoreExtraElements]
    public class ConfessionOption
    {
        [BsonElement("label")]
        public string Label { get; set; } = string.Empty; 

        [BsonElement("pdfPhrase")]
        public string? PdfPhrase { get; set; }
        
        [BsonElement("isExclusive")]
        public bool IsExclusive { get; set; }
        
        [BsonElement("dialogType")]
        public string? DialogType { get; set; }
    }
}