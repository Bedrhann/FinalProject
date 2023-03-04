using FinalProject.Application.Interfaces.Contexts;
using FinalProject.Application.Interfaces.Repositories.MongoRepositories._Common;
using FinalProject.Domain.Entities.Common;
using MongoDB.Driver;

namespace FinalProject.Persistance.Repositories.MongoRepositories._Common
{
    public class MongoCommandRepository<T> : IMongoCommandRepository<T> where T : BaseMongoEntity
    {
        private readonly IMongoDbContext _context;
        private string _collectionName;

        public MongoCommandRepository(IMongoDbContext context, string collectionName)
        {
            _context = context;
            _collectionName = collectionName;
        }

        public IMongoCollection<T> _collection => _context.Database.GetCollection<T>(_collectionName);


        public async Task AddAsync(T model)
        {
            await _collection.InsertOneAsync(model);
        }


        public async Task RemoveByIdAsync(Guid id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }


        public async Task Update(Guid id, T updatedEntity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedEntity);
            return;
        }
    }
}
