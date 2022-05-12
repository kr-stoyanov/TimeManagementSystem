using CoreBusiness.Enums;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class TimeCard
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ProjectName { get; set; }

        [Required]
        [MaxLength(1250)]
        public string? TaskName { get; set; }

        public string? Notes { get; set; }

        public TimeCardStatus Status { get; set; }

        public TimeSpan TimeSpent { get; set; }

        public bool IsRunning { get; set; }

        public TimeSpan StopwatchValue { get; set; }
    }
}
