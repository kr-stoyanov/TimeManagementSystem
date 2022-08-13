using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetProjectByIdUseCase
    {
        Project Execute(string id);
    }
}
