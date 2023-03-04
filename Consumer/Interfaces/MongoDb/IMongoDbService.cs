using Consumer.Models;

namespace Consumer.Interfaces.MongoDb
{
    public interface IMongoDbService
    {
        Task<List<ArchivedShopList>> GetAsync();
        Task<ArchivedShopList> GetAsync(Guid id);
        Task CreateAsync(ArchivedShopList ListArch);
        Task UpdateAsync(Guid id, ArchivedShopList ListArch);
        Task RemoveAsync(Guid id);
    }
}
