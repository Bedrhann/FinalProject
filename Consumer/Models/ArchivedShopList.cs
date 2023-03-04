using MongoDB.Bson.Serialization.Attributes;

namespace Consumer.Models
{
    public class ArchivedShopList
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
