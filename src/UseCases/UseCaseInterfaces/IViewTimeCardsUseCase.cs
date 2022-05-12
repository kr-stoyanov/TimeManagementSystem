using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public  interface IViewTimeCardsUseCase
    {
        IEnumerable<TimeCard> Execute();
    }
}
