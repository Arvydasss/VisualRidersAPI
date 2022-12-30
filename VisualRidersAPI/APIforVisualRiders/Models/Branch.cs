namespace apiForVisualRiders.Models
{
    public enum BranchStatus
    {
        Active,
        Deleted
    }
    public enum WorkingDays
    {
        Monday = 1 << 0,
        Tuesday = 1 << 1,
        Wednesday = 1 << 2,
        Thursday = 1 << 3,
        Friday = 1 << 4,
        Saturday = 1 << 5,
        Sunday = 1 << 6
    }
    public class Branch
    {
        public Guid Id { get; set; }

        public string Address { get; set; }

        //public Time WorkingHourStart { get; set; }
        public string WorkingHourStartStr { get; set; }

        //public Time WorkingHourEnd { get; set; }
        public string WorkingHourEndStr { get; set; }

        public WorkingDays WorkingDays { get; set; }

        public string Contacts { get; set; }

        public BranchStatus Status { get; set; }

        public Guid Company { get; set; }

    }
}