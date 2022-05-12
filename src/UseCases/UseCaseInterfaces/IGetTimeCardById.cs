using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetTimeCardById
    {
        TimeCard Execute(int id);
    }
}
