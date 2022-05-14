using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class TimeCardHistoryUseCase : ITimeCardHistoryUseCase
    {
        private readonly ITimeCardMongoDbRepository timeCardRepository;

        public TimeCardHistoryUseCase(ITimeCardMongoDbRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }
        public IEnumerable<TimeCard> Execute()
        {
            return this.timeCardRepository.ReadClosed();
        }
    }
}
