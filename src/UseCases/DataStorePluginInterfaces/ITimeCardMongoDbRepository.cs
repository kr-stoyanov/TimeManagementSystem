using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITimeCardMongoDbRepository
    {
        TimeCard Create(TimeCard timeCard);

        IEnumerable<TimeCard> Read();

        TimeCard Find(string id);

        void Update(TimeCard timeCard);

        IEnumerable<TimeCard> ReadClosed();
    }
}
