using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class TimeCard
    {
        public int TimeCardId { get; set; }

        [Required]
        public string? UserName { get; set; }

        public string? ProjectName { get; set; }

        public string? TaskName { get; set; }

        public string? Notes { get; set; }

        public int? TimeSpent { get; set; }
    }
}
