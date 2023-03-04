using FinalProject.Domain.Entities.Common;
using System.Linq.Expressions;


namespace FinalProject.Application.Interfaces.Repositories.Common
{
    public interface IBaseQueryRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(string id);
    }
}
