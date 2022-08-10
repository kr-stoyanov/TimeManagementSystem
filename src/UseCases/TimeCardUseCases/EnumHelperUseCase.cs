using System.Reflection;
using System.ComponentModel.DataAnnotations;
using UseCases.UseCaseInterfaces;

namespace UseCases.TimeCardUseCases
{
    public class EnumHelperUseCase : IEnumHelperUseCase
    {
        public string GetStatusDisplayName(Enum status)
        {
            return status.GetType()
                      .GetMember(status.ToString())
                      .FirstOrDefault()
                      ?.GetCustomAttribute<DisplayAttribute>(false)
                      ?.Name
                      ?? status.ToString();
        }
    }
}
