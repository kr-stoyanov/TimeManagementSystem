using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TimeCardInMemoryRepository : ITimeCardRepository
    {
        private List<TimeCard> timeCards;

        public TimeCardInMemoryRepository()
        {
            timeCards = new List<TimeCard>()
            {
                new TimeCard(){ UserName = "kstoyanov@mail.com", ProjectName = "Sundowning", TaskName = "Process Manual Documents in Databricks", Notes = "Use python", TimeSpent = TimeSpan.FromHours(8) },
                new TimeCard(){ UserName = "kstoyanov@mail.com", ProjectName = "Sundowning", TaskName = "Process GSA fles", Notes = "Use dotnet", TimeSpent = TimeSpan.FromHours(48) },
            };
        }
        public IEnumerable<TimeCard> GetTimeCards()
        {
                return timeCards;
        }
    }
}