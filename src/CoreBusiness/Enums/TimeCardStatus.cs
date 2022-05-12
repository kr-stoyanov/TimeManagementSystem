using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Enums
{
    public enum TimeCardStatus
    {
        New = 2,

        [Display(Name = "In Progress")]
        InProgress = 4,
        
        [Display(Name = "On Hold")]
        OnHold = 8,
        Done = 16,
        Closed = 32,
    }
}
