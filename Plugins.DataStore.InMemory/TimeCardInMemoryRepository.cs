using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TimeCardInMemoryRepository : ITimeCardRepository
    {
        private readonly List<TimeCard> timeCards;

        public TimeCardInMemoryRepository()
        {
            timeCards = new List<TimeCard>()
            {
                new TimeCard(){ Id = 1, UserName = "kstoyanov@mail.com", ProjectName = "Sundowning", TaskName = "Process Manual Documents in Databricks", Notes = "Add new notebook in Databricks - use python", TimeSpent = 8 },
                new TimeCard(){ Id = 2, UserName = "kstoyanov@mail.com", ProjectName = "Sundowning", TaskName = "Process GSA fles", Notes = "Extract attachments and upload them to azure blob storage - use dotnet", TimeSpent = 48 },
            };
        }

        public void AddTimeCard(TimeCard timeCard)
        {
            var maxId = timeCards.Max(x => x.Id);
            timeCard.Id = maxId + 1;

            timeCards.Add(timeCard);
        }

        public void EditTimeCard(TimeCard timeCard)
        {
            var timeCardToEdit = GetTimeCardById(timeCard.Id);
            if (timeCardToEdit != null) timeCardToEdit = timeCard;
        }

        public TimeCard? GetTimeCardById(int id) => timeCards?.FirstOrDefault(x => x.Id == id);

        public IEnumerable<TimeCard> GetTimeCards() => timeCards;
    }
}