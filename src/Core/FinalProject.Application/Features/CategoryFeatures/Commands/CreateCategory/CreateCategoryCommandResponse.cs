using FinalProject.Application.DTOs.Base;
using FinalProject.Application.Wrappers.Base;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse<BaseCreateDto>
    {
        [System.Text.Json.Serialization.JsonPropertyName("newCategoryId")]
        public Guid NewCategoryId { get; set; }
    }
}
