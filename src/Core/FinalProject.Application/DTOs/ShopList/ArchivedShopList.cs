using FinalProject.Domain.Entities.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace FinalProject.Application.DTOs.ShopList
{
    public class ArchivedShopList : BaseMongoEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
