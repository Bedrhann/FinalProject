using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Persistence.Repositories.ShopListRepositories
{
    public class ShopListQueryArchiveRepository : IShopListQueryArchiveRepository
    {
        private readonly MsSqlDbContext _context;
        public ShopListQueryArchiveRepository(MsSqlDbContext context)
        {
            _context = context;
        }

        public DbSet<ShopListQueryDto> Table => _context.Set<ShopListQueryDto>();

        public IQueryable<ShopListQueryDto> GetAll()
        {
            return Table;
        }
    }
}
