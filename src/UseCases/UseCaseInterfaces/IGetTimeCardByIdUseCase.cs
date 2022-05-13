using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetTimeCardByIdUseCase
    {
        TimeCard Execute(string id);
    }
}
