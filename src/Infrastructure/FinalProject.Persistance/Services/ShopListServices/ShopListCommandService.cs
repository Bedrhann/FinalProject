using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Domain.Entities;

namespace FinalProject.Persistance.Services.ShopListServices
{
    public class ShopListCommandService : BaseCommandService<ShopListCommandDto, ShopList>, IShopListCommandService
    {
        private readonly ICommandRepository<ShopList> repository;

        public ShopListCommandService(ICommandRepository<ShopList> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
