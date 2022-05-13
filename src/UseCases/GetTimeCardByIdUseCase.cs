using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
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
            return this.timeCardRepository.Find(id);
        }
    }
}
