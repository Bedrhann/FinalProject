using FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.ShopListService
{
    public interface IShopListCommandService : IBaseCommandService<CreateShopListCommandRequest, ShopList>
    {
    }
}
