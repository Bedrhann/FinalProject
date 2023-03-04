using Consumer.Interfaces.MongoDb;
using Consumer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Consumer.Services.MongoDb
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoCollection<ArchivedShopList> _listCollection;
        public MongoDbService(IOptions<MongoDbSettings> options)
        {
            var mongoclient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoclient.GetDatabase(options.Value.DatabaseName);
            _listCollection = mongoDatabase.GetCollection<ArchivedShopList>(options.Value.ListsCollectionName);
        }

        public async Task<List<ArchivedShopList>> GetAsync() =>
            await _listCollection.Find(_ => true).ToListAsync();

        public async Task<ArchivedShopList?> GetAsync(Guid id) =>
            await _listCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ArchivedShopList newListArch) =>
            await _listCollection.InsertOneAsync(newListArch);

        public async Task UpdateAsync(Guid id, ArchivedShopList updatedListArch) =>
            await _listCollection.ReplaceOneAsync(x => x.Id == id, updatedListArch);

        public async Task RemoveAsync(Guid id) =>
            await _listCollection.DeleteOneAsync(x => x.Id == id);
    }
}