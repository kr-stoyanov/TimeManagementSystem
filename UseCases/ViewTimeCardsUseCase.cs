using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

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