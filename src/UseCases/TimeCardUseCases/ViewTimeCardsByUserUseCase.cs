using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.TimeCardUseCases
{
    public class ViewTimeCardsByUserUseCase : IViewTimeCardsByUserUseCase
    {
        private readonly ITimeCardMongoDbRepository timeCardRepository;

        public ViewTimeCardsByUserUseCase(ITimeCardMongoDbRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }
        public IEnumerable<TimeCard> Execute(string userName)
        {
            return timeCardRepository.ReadByUser(userName);
        }
    }
}