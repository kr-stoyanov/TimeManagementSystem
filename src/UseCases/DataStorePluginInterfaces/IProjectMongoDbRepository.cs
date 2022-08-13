using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProjectMongoDbRepository
    {
        void Create(Project project);

        IEnumerable<Project> Read();

        Project Find(string id);

        void Update(Project project);
    }
}
