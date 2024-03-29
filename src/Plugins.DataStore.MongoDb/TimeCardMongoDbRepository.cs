﻿using CoreBusiness;
using CoreBusiness.Enums;
using MongoDB.Driver;
using Plugins.DataStore.MongoDb.Models;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.MongoDb
{
    public class TimeCardMongoDbRepository : ITimeCardMongoDbRepository
    {
        private readonly IMongoCollection<TimeCard> timeCards;
        private readonly IMongoCollection<ApplicationUser> users;

        public TimeCardMongoDbRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.timeCards = database.GetCollection<TimeCard>(settings.TimeCardsCollection);
            this.users = database.GetCollection<ApplicationUser>(settings.UsersCollection);
        }

        public TimeCard Create(TimeCard timeCard)
        {
            var user = this.users.Find(x => x.UserName == timeCard.UserName).FirstOrDefault();
            timeCard.CreatedOn = DateTime.Now;
            timeCard.LastModifiedOn = DateTime.Now;
            timeCard.UserId = user.Id;
            this.timeCards.InsertOne(timeCard);
            return timeCard;
        }

        public IEnumerable<TimeCard> ReadByUser(string userName) =>
            this.timeCards.Find(x => x.Status != TimeCardStatus.Closed && x.UserName.ToLower() == userName.ToLower()).ToList();

        public TimeCard Find(string id) =>
            this.timeCards.Find(tc => tc.Id == id).SingleOrDefault();

        public void Update(TimeCard timeCard) =>
            this.timeCards.ReplaceOne(tc => tc.Id == timeCard.Id, timeCard);

        public IEnumerable<TimeCard> ReadClosedByUser(string userName) =>
            this.timeCards.Find(x => x.Status == TimeCardStatus.Closed 
                           && x.UserName.ToLower() == userName.ToLower()).ToList();

        public IEnumerable<TimeCard> ReadForExportByUser(string userName) => 
            this.timeCards.Find(x => x.UserName.ToLower() == userName.ToLower()).ToList();
    }
}