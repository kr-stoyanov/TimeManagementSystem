using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.TimeCardUseCases
{
    public class GetTimeCardByIdUseCase : IGetTimeCardByIdUseCase
    {
        private readonly ITimeCardMongoDbRepository timeCardRepository;

        public GetTimeCardByIdUseCase(ITimeCardMongoDbRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }
        public TimeCard Execute(string id)
        {
            return timeCardRepository.Find(id);
        }
    }
}
