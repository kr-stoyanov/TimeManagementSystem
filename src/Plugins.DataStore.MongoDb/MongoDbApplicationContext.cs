using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbGenericRepository;

namespace Plugins.DataStore.MongoDb
{
    internal class MongoDbApplicationContext : IMongoDbContext
    {
        public IMongoClient Client => throw new NotImplementedException();

        public IMongoDatabase Database => throw new NotImplementedException();

        public void DropCollection<TDocument>(string partitionKey = null)
        {
            throw new NotImplementedException();
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string partitionKey = null)
        {
            throw new NotImplementedException();
        }

        public void SetGuidRepresentation(GuidRepresentation guidRepresentation)
        {
            throw new NotImplementedException();
        }
    }
}
