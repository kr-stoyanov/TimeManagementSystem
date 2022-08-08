namespace Plugins.DataStore.MongoDb.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string? ConnectionString { get; set; }

        public string? DatabaseName { get; set; }

        public string? TimeCardsCollection { get; set; }

        public string? UsersCollection { get; set; }
    }
}
