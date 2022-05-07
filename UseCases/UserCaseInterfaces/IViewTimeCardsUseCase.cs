using CoreBusiness;

namespace UseCases.UserCaseInterfaces
{
    public  interface IViewTimeCardsUseCase
    {
        public IEnumerable<TimeCard> Execute();
    }
}
