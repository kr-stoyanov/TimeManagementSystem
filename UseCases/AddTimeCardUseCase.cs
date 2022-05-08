using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UserCaseInterfaces;

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
