using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITimeCardRepository
    {
        public IEnumerable<TimeCard> GetTimeCards();
    }
}
