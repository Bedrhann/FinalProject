using FinalProject.Domain.Entities.Common;

namespace FinalProject.Application.Interfaces.Repositories.MongoRepositories._Common
{
    public interface IMongoCommandRepository<T> where T : BaseMongoEntity
    {
        Task AddAsync(T model);
        Task RemoveByIdAsync(Guid id);
        Task Update(Guid id, T updatedEntity);
    }
}
