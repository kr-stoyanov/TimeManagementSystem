using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProjectUseCases
{
    public class ViewProjectsUseCase : IViewProjectsUseCase
    {
        private readonly IProjectMongoDbRepository projectsRepository;

        public ViewProjectsUseCase(IProjectMongoDbRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        public IEnumerable<Project> Execute()
        {
            return projectsRepository.Read();
        }
    }
}
