using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITimeCardRepository
    {
        IEnumerable<TimeCard> GetTimeCards();
        void AddTimeCard(TimeCard timeCard);
        void EditTimeCard(TimeCard timeCard);
        TimeCard GetTimeCardById(int id);
    }
}
