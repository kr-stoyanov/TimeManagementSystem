using CoreBusiness;
using CoreBusiness.Enums;
using MongoDB.Driver;
using Plugins.DataStore.MongoDb.Models;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.MongoDb
{
    public class TimeCardMongoDbRepository : ITimeCardMongoDbRepository
    {
        private readonly IMongoCollection<TimeCard> timeCards;

        public TimeCardMongoDbRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.timeCards = database.GetCollection<TimeCard>(settings.CollectionName);
        }

        public TimeCard Create(TimeCard timeCard)
        {
            timeCard.CreatedOn = DateTime.Now;
            timeCard.LastModifiedOn = DateTime.Now;
            timeCards.InsertOne(timeCard);
            return timeCard;
        }

        public IEnumerable<TimeCard> Read() =>
            timeCards.Find(x => x.Status != TimeCardStatus.Closed).ToList();

        public TimeCard Find(string id) =>
            this.timeCards.Find(tc => tc.Id == id).SingleOrDefault();

        public void Update(TimeCard timeCard) =>
            timeCards.ReplaceOne(tc => tc.Id == timeCard.Id, timeCard);

        public IEnumerable<TimeCard> ReadClosed() =>
            timeCards.Find(x => x.Status == TimeCardStatus.Closed).ToList();
    }
}