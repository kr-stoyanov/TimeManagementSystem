using CoreBusiness;
using MongoDB.Driver;
using Plugins.DataStore.MongoDb.Models;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.MongoDb
{
    public class ProjectMongoDbRepository : IProjectMongoDbRepository
    {
        private readonly IMongoCollection<Project> projects;
        private readonly IMongoCollection<ApplicationUser> users;

        public ProjectMongoDbRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            this.projects = database.GetCollection<Project>(settings.ProjectsCollection);
            this.users = database.GetCollection<ApplicationUser>(settings.UsersCollection);
        }

        public void Create(Project project)
        {
            var user = this.users.Find(x => x.UserName == project.CreatedBy).FirstOrDefault();
            project.CreatedOn = DateTime.Now;
            project.LastModifiedOn = DateTime.Now;
            project.CreatedBy = user.UserName;
            this.projects.InsertOne(project);
        }

        public Project Find(string id) =>
            this.projects.Find(p => p.Id == id).SingleOrDefault();

        public IEnumerable<Project> Read() => this.projects.Find(x => true).ToList();

        public void Update(Project project) =>
            this.projects.ReplaceOne(p => p.Id == project.Id, project);
       
    }
}
