using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.ShopListService
{
    public interface IShopListCommandService : IBaseCommandService<ShopListCommandDto, ShopList>
    {
        Task<BaseResponse<ShopListCommandDto>> SoftRemoveAsync(Guid id);
    }
}
