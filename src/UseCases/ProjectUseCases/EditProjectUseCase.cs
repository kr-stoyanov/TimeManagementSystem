using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProjectUseCases
{
    public class EditProjectUseCase : IEditProjectUseCase
    {
        private readonly IProjectMongoDbRepository projectRepository;

        public EditProjectUseCase(IProjectMongoDbRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public void Execute(Project project)
        {
            this.projectRepository.Update(project);
        }
    }
}
