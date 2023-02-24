using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Domain.Entities.Common;
using FinalProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace FinalProject.Persistence.Repositories.Common
{
    public class BaseQueryRepository<T> : IBaseQueryRepository<T> where T : BaseEntity
    {
        private readonly MsSqlDbContext _context;

        public BaseQueryRepository(MsSqlDbContext context)
        {
            _context = context;
        }
        DbSet<T> IBaseRepository<T>.Table => throw new NotImplementedException();

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {

            return Table;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.FirstOrDefaultAsync(expression);
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return Table.Where(expression);

        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FindAsync(Guid.Parse(id));
        }

    }
}
