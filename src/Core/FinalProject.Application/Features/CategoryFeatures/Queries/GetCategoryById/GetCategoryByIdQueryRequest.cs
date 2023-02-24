using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryRequest : IRequest<BaseResponse<CategoryQueryDto>>
    {
        public Guid Id { get; set; }
    }
}
