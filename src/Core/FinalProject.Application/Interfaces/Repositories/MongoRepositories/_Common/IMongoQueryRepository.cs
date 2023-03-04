using FinalProject.Domain.Entities.Common;
using System.Linq.Expressions;

namespace FinalProject.Application.Interfaces.Repositories.MongoRepositories._Common
{
    public interface IMongoQueryRepository<T> where T : BaseMongoEntity
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetWhere(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(Guid id);
    }
}
