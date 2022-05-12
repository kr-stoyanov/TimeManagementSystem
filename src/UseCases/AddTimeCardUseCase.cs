using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class AddTimeCardUseCase : IAddTimeCardUseCase
    {
        private readonly ITimeCardRepository timeCardRepository;

        public AddTimeCardUseCase(ITimeCardRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }

        public void Execute(TimeCard timeCard)
        {
            timeCardRepository.AddTimeCard(timeCard);
        }
    }
}
