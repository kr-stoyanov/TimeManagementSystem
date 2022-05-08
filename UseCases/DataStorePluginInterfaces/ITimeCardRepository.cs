using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITimeCardRepository
    {
        IEnumerable<TimeCard> GetTimeCards();
        void AddTimeCard(TimeCard timeCard);
    }
}
