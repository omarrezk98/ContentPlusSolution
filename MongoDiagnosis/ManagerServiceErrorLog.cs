using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDiagnosis
{
    [BsonIgnoreExtraElements]
    public class ManagerServiceErrorLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ManagerServiceErrorLogId { get; set; } = string.Empty;
        [BsonElement("managerId")]
        public string? ManagerId { get; set; }
        [BsonElement("source")]
        public string? Source { get; set; }
        [BsonElement("innerException")]
        public object? InnerException { get; set; }
        [BsonElement("message")]
        public string? Message { get; set; }
        [BsonElement("stackTrace")]
        public string? StackTrace { get; set; }
        [BsonElement("uRL")]
        public string? URL { get; set; }
        [BsonElement("model")]
        public object? Model { get; set; }
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
