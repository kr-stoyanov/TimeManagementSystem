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
    public class GetProjectByIdUseCase : IGetProjectByIdUseCase
    {
        private readonly IProjectMongoDbRepository projectRepository;

        public GetProjectByIdUseCase(IProjectMongoDbRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public Project Execute(string id)
        {
            return this.projectRepository.Find(id);
        }
    }
}
