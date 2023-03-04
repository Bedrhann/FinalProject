using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Domain.Entities;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.Common;

namespace FinalProject.Persistence.Repositories.ShopListRepositories
{
    public class ShopListCommandRepository : BaseCommandRepository<ShopList>, IShopListCommandRepository
    {
        public ShopListCommandRepository(MsSqlDbContext context) : base(context)
        {

        }
    }
}
