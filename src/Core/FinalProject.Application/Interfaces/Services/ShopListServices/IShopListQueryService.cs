using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.ShopListService
{
    public interface IShopListQueryService : IBaseQueryService<ShopListQueryDto, ShopList>
    {
        Task<BaseResponseWithPaging<List<ShopListQueryDto>>> GetAllAsync(GetAllShopListQueryRequest request,bool isByUser);
    }
}
