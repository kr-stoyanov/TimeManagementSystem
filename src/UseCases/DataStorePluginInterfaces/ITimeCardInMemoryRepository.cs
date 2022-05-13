using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITimeCardInMemoryRepository
    {
        IEnumerable<TimeCard> GetTimeCards();
        void AddTimeCard(TimeCard timeCard);
        void EditTimeCard(TimeCard timeCard);
        TimeCard GetTimeCardById(string id);
    }
}
