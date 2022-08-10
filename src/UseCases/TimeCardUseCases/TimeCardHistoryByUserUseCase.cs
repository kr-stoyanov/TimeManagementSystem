using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.TimeCardUseCases
{
    public class TimeCardHistoryByUserUseCase : ITimeCardHistoryByUserUseCase
    {
        private readonly ITimeCardMongoDbRepository timeCardRepository;

        public TimeCardHistoryByUserUseCase(ITimeCardMongoDbRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }
        public IEnumerable<TimeCard> Execute(string userName)
        {
            return timeCardRepository.ReadClosedByUser(userName);
        }
    }
}
