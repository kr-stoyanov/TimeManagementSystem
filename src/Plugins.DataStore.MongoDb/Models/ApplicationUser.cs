using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Plugins.DataStore.MongoDb.Models
{
    [CollectionName("users")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    { }
}
