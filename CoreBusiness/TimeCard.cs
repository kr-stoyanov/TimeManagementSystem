using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class TimeCard
    {
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        public string? ProjectName { get; set; }

        public string? TaskName { get; set; }

        public string? Notes { get; set; }

        public TimeSpan TimeSpent { get; set; }

        public bool IsRunning { get; set; }

        public TimeSpan StopwatchValue { get; set; }

    }
}
