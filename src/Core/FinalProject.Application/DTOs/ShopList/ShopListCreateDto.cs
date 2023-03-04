using FinalProject.Domain.Entities.Common;

namespace FinalProject.Application.DTOs.ShopList
{
    public class ShopListCreateDto : BaseEntity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public string AppUserId { get; set; }
    }
}
