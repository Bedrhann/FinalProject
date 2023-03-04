using FinalProject.Application.Interfaces.Contexts;
using FinalProject.Application.Interfaces.Repositories.MongoRepositories._Common;
using FinalProject.Domain.Entities.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace FinalProject.Persistance.Repositories.MongoRepositories._Common
{
    public class MongoQueryRepository<T> : IMongoQueryRepository<T> where T : BaseMongoEntity
    {
        private readonly IMongoDbContext _context;
        private string _collectionName;

        public MongoQueryRepository(IMongoDbContext context, string collectionName)
        {
            _context = context;
            _collectionName = collectionName;
        }

        public IMongoCollection<T> _collection => _context.Database.GetCollection<T>(_collectionName);


        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<List<T>> GetWhere(Expression<Func<T, bool>> expression)
        {
            return await _collection.Find(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
