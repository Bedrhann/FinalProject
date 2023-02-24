using FinalProject.Application.DTOs.ShopList;

namespace FinalProject.Application.Interfaces.Repositories.ShopListRepositories
{
    public interface IShopListCommandArchiveRepository
    {
        Task SendCompletedShopList(ShopListQueryDto model);
        Task SaveAsync();
    }
}

