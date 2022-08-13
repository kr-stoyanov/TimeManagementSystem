using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.TimeCardUseCases
{
    public class AddTimeCardUseCase : IAddTimeCardUseCase
    {
        private readonly ITimeCardMongoDbRepository timeCardRepository;

        public AddTimeCardUseCase(ITimeCardMongoDbRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }

        public void Execute(TimeCard timeCard)
        {
            timeCardRepository.Create(timeCard);
        }
    }
}
