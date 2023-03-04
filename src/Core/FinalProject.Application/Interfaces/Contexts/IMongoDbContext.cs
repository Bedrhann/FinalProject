using MongoDB.Driver;

namespace FinalProject.Application.Interfaces.Contexts
{
    public interface IMongoDbContext
    {
        IMongoDatabase Database { get; }
    }
}
