using FinalProject.Application.DTOs.ShopList;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.ShopListService
{
    public interface IShopListCommandService : IBaseCommandService<ShopListCommandDto, ShopList>
    {
    }
}
