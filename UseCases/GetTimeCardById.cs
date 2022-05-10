using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class GetTimeCardById : IGetTimeCardById
    {
        private readonly ITimeCardRepository timeCardRepository;

        public GetTimeCardById(ITimeCardRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }
        public TimeCard Execute(int id)
        {
            return this.timeCardRepository.GetTimeCardById(id);
        }
    }
}
