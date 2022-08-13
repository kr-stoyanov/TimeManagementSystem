using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProjectsUseCase
    {
        IEnumerable<Project> Execute();
    }
}
