namespace CoreBusiness
{
    public class TimeCard
    {
        public string? UserName { get; set; }

        public string? ProjectName { get; set; }

        public string? TaskName { get; set; }

        public string? Notes { get; set; }

        public TimeSpan? TimeSpent { get; set; }
    }
}
