using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public  interface ITimeCardHistoryByUserUseCase
    {
        IEnumerable<TimeCard> Execute(string userName);
    }
}
