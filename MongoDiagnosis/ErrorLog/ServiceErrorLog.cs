using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.ErrorLog
{
    [BsonIgnoreExtraElements]
    public class ServiceErrorLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceErrorLogId { get; set; } = string.Empty;
        [BsonElement("serviceErrorLogType")]
        public string ServiceErrorLogType { get; set; } = default!;
        [BsonElement("clientId")]
        public int? ClientId { get; set; }
        [BsonElement("userId")]
        public string? UserId { get; set; }
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
        public string? Model { get; set; }
        [BsonElement("dateLog")]
        public DateTime DateLog { get; set; } = DateTime.UtcNow;
    }
}