using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProjectUseCases
{
    public class AddProjectUseCase : IAddProjectUseCase
    {
        private readonly IProjectMongoDbRepository projectsRepository;

        public AddProjectUseCase(IProjectMongoDbRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }

        public void Execute(Project project)
        {
            this.projectsRepository.Create(project);
        }
    }
}
