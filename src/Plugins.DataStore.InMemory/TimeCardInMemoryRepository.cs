using CoreBusiness;
using CoreBusiness.Enums;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TimeCardInMemoryRepository : ITimeCardInMemoryRepository
    {
        private readonly List<TimeCard> timeCards;

        public TimeCardInMemoryRepository()
        {
            timeCards = new List<TimeCard>()
            {
                new TimeCard(){ Id = Guid.NewGuid().ToString(), UserName = "Krasimir Stoyanov", ProjectName = "Sundowning", TaskName = "Process Manual Documents in Databricks", Notes = "Add new notebook in Databricks - use python", Status = TimeCardStatus.New },
                new TimeCard(){ Id = Guid.NewGuid().ToString(), UserName = "Krasimir Stoyanov", ProjectName = "Sundowning", TaskName = "Process GSA fles", Notes = "Extract attachments and upload them to azure blob storage - use dotnet", Status = TimeCardStatus.New},
                new TimeCard(){ Id = Guid.NewGuid().ToString(), UserName = "Krasimir Stoyanov", ProjectName = "Sundowning", TaskName = "Onboard newcomer", Notes = "Induction: ADF, ADO Pipeline, C# Solution", Status = TimeCardStatus.New},
                new TimeCard(){ Id = Guid.NewGuid().ToString(), UserName = "Krasimir Stoyanov", ProjectName = "Sundowning", TaskName = "Bug fixing", Notes = "", Status = TimeCardStatus.New},
            };
        }

        public void AddTimeCard(TimeCard timeCard)
        {
            var maxId = timeCards.Max(x => x.Id);
            timeCard.Id = Guid.NewGuid().ToString();

            timeCards.Add(timeCard);
        }

        public void EditTimeCard(TimeCard timeCard)
        {
            var timeCardToEdit = GetTimeCardById(timeCard.Id.ToString());
            if (timeCardToEdit != null) timeCardToEdit = timeCard;
        }

        public TimeCard? GetTimeCardById(string id) => timeCards?.FirstOrDefault(x => x.Id.ToString() == id);

        public IEnumerable<TimeCard> GetTimeCards() => timeCards;
    }
}