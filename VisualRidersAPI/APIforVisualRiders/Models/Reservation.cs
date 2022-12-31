namespace apiForVisualRiders.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ReservationStatus ReservationStatus { get; set; }

        public Guid ServiceId { get; set; }

       // public Guid Tax { get; set; } DOES NOT EXIST

        public Guid OrderId { get; set; }

        public Guid EmployeeId { get; set; }
    }
    public enum ReservationStatus
    {
        Submitted,
        Registered,
        ChangedTime,
        Cancelled
    }
}