using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class EditTimeCardUseCase : IEditTimeCardUseCase
    {
        private readonly ITimeCardRepository timeCardRepository;

        public EditTimeCardUseCase(ITimeCardRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }
        public void Execute(TimeCard timeCard)
        {
            this.timeCardRepository.EditTimeCard(timeCard);
        }
    }
}
