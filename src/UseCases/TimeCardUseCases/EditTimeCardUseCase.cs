using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.TimeCardUseCases
{
    public class EditTimeCardUseCase : IEditTimeCardUseCase
    {
        private readonly ITimeCardMongoDbRepository timeCardRepository;

        public EditTimeCardUseCase(ITimeCardMongoDbRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }
        public void Execute(TimeCard timeCard)
        {
            timeCardRepository.Update(timeCard);
        }
    }
}
