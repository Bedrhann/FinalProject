using MongoDB.Bson.Serialization.Attributes;

namespace FinalProject.Domain.Entities.Common
{
    public class BaseMongoEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
