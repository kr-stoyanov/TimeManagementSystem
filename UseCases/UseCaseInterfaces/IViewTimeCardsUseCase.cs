using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public  interface IViewTimeCardsUseCase
    {
        public IEnumerable<TimeCard> Execute();
    }
}
