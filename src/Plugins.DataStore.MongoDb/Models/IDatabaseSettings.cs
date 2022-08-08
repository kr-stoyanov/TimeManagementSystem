namespace Plugins.DataStore.MongoDb.Models
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string? TimeCardsCollection { get; set; }

        string? UsersCollection { get; set; }
    }
}
