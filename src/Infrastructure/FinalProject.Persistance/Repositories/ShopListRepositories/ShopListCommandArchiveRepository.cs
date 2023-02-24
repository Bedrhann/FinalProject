using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Domain.Entities;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FinalProject.Persistence.Repositories.ShopListRepositories
{
    public class ShopListCommandArchiveRepository : IShopListCommandArchiveRepository
    {
        private readonly MsSqlDbContext _context;
        public ShopListCommandArchiveRepository(MsSqlDbContext context)
        {
            _context = context;
        }

        public DbSet<ShopListQueryDto> Table => _context.Set<ShopListQueryDto>();

        public async Task SendCompletedShopList(ShopListQueryDto model)
        {
            await Table.AddAsync(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
