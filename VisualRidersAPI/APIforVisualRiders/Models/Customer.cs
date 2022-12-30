namespace apiForVisualRiders.Models
{
    public enum CustomerStatus
    {
        Deleted,
        Active
    }
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public CustomerStatus Status { get; set; }
        public Guid DiscountId { get; set; }
    }
}