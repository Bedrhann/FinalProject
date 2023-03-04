using FinalProject.Domain.Entities.Common;

namespace FinalProject.Application.DTOs.Category
{
    public class CategoryCreateDto : BaseEntity
    {
        public Guid ShopListId { get; set; }
    }
}
