using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class ViewTimeCardsUseCase : IViewTimeCardsUseCase
    {
        private readonly ITimeCardMongoDbRepository timeCardRepository;

        public ViewTimeCardsUseCase(ITimeCardMongoDbRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        } 
        public IEnumerable<TimeCard> Execute()
        {
            return timeCardRepository.Read();
        }
    }
}