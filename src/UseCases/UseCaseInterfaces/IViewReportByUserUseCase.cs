using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewReportByUserUseCase
    {
        IEnumerable<TimeCard> Execute(string userName);
    }
}
