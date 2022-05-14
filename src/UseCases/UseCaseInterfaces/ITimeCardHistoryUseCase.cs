using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public  interface ITimeCardHistoryUseCase
    {
        IEnumerable<TimeCard> Execute();
    }
}
