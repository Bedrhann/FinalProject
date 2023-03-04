using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Domain.Entities;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.Common;

namespace FinalProject.Persistence.Repositories.ShopListRepositories
{
    public class ShopListQueryRepository : BaseQueryRepository<ShopList>, IShopListQueryRepository
    {
        public ShopListQueryRepository(MsSqlDbContext context) : base(context)
        {
        }
    }
}
