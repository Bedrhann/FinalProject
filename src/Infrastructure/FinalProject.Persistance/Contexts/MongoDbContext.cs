using FinalProject.Application.Interfaces.Contexts;
using FinalProject.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject.Persistance.Contexts
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            var mongoclient = new MongoClient(options.Value.ConnectionString);
            _database = mongoclient.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoDatabase Database => _database;
    }
}
