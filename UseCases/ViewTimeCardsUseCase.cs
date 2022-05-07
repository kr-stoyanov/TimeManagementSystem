using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UserCaseInterfaces;

namespace UseCases
{
    public class ViewTimeCardsUseCase : IViewTimeCardsUseCase
    {
        private readonly ITimeCardRepository timeCardRepository;

        public ViewTimeCardsUseCase(ITimeCardRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        } 
        public IEnumerable<TimeCard> Execute()
        {
            return timeCardRepository.GetTimeCards();
        }
    }
}