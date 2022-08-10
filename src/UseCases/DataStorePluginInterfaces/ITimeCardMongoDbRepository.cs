using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITimeCardMongoDbRepository
    {
        TimeCard Create(TimeCard timeCard);

        IEnumerable<TimeCard> ReadByUser(string userName);

        TimeCard Find(string id);

        void Update(TimeCard timeCard);

        IEnumerable<TimeCard> ReadClosedByUser(string userName);

        IEnumerable<TimeCard> ReadForExportByUser(string userName);
    }
}
