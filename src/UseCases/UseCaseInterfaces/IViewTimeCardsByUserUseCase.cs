using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public  interface IViewTimeCardsByUserUseCase
    {
        IEnumerable<TimeCard> Execute(string userName);
    }
}
