using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Plugins.DataStore.MongoDb.Models
{
    [CollectionName("roles")]
    public class ApplicationRole : MongoIdentityRole<Guid>
    { }
}
