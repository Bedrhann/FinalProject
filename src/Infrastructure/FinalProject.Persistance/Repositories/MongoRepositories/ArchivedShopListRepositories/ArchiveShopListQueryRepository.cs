using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Contexts;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Persistance.Repositories.MongoRepositories._Common;

namespace FinalProject.Persistance.Repositories.MongoRepositories.ArchivedShopListRepositories
{
    public class ArchiveShopListQueryRepository : MongoQueryRepository<ArchivedShopList>, IArchiveShopListQueryRepository
    {
        public const string _collectionName = "ArchivedShopLists";
        public ArchiveShopListQueryRepository(IMongoDbContext context) : base(context, _collectionName)
        {
        }
    }
}
