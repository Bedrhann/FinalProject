using FinalProject.Domain.Entities.Common;

namespace FinalProject.Application.DTOs.Category
{
    public class CategoryCommandDto : BaseEntity
    {
        public Guid ShopListId { get; set; }
        public string Name { get; set; }
    }
}
