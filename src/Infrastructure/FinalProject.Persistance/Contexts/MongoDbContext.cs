using MongoDB.Driver;

namespace FinalProject.Persistance.Contexts
{
    public class MongoDbConnect
    {

        public const string MongoConnectionString = "mongodb://docker:mongopw@localhost:49153";
        public const string MongoDatabaseName = "DENEME";

        public IMongoCollection<T> ConnectToMongo<T>(string collection)
        {
            var client = new MongoClient(MongoConnectionString);
            var db = client.GetDatabase(MongoDatabaseName);
            return db.GetCollection<T>(collection);
        }
    }
}
