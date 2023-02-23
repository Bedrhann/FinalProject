using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Domain.Entities;

namespace FinalProject.Persistance.Services.ShopListServices
{
    public class ShopListQueryService : BaseQueryService<ShopListQueryDto, ShopList>, IShopListQueryService
    {
        private readonly IQueryRepository<ShopList> repository;

        public ShopListQueryService(IQueryRepository<ShopList> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
