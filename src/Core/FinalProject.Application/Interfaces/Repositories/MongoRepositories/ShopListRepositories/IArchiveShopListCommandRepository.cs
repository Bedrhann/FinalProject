using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.MongoRepositories._Common;

namespace FinalProject.Application.Interfaces.Repositories.ShopListRepositories
{
    public interface IArchiveShopListCommandRepository : IMongoCommandRepository<ArchivedShopList>
    {
       
    }
}

