using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.Report
{
    public class ViewReportByUserUseCase : IViewReportByUserUseCase
    {
        private readonly ITimeCardMongoDbRepository timeCardRepository;

        public ViewReportByUserUseCase(ITimeCardMongoDbRepository timeCardRepository)
        {
            this.timeCardRepository = timeCardRepository;
        }
        public IEnumerable<TimeCard> Execute(string userName)
        {
            return this.timeCardRepository.ReadForExportByUser(userName);
        }
    }
}
