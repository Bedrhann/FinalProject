using MongoDB.Bson.Serialization.Attributes;

namespace Consumer.Models
{
    public class ArchivedShopList
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }

    }
}
