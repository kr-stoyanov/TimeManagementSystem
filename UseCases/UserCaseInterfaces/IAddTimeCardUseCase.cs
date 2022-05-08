using CoreBusiness;

namespace UseCases.UserCaseInterfaces
{
    public interface IAddTimeCardUseCase
    {
        void Execute(TimeCard timeCard);
    }
}
