using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.ShopListService
{
    public interface IShopListCommandService : IBaseCommandService<ShopListCreateDto, ShopListUpdateDto, ShopList>
    {
        Task<BaseResponse<object>> SoftRemoveAsync(Guid id);
    }
}
