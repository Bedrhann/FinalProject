using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Paging;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory
{
    public class GetAllProductByCategoryQueryRequest : BasePagingRequest, IRequest<BaseResponseWithPaging<List<ProductQueryDto>>>
    {
        public Guid CategoryId { get; set; }
        public string? SearchByName { get; set; }
        public DateTime? CreationRangeCeiling { get; set; }
        public DateTime? CreationRangeLower { get; set; }
        public DateTime? UpdateRangeCeiling { get; set; }
        public DateTime? UpdateRangeLower { get; set; }
    }
}
