using FinalProject.Domain.Entities.Common;

namespace FinalProject.Application.DTOs.ShopList
{
    public class ShopListUpdateDto : BaseEntity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
