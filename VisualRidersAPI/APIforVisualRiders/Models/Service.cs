namespace apiForVisualRiders.Models
{
    public enum ServiceStatus
    {
        Deleted,
        Active
    }
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public ServiceType Type { get; set; } DOES NOT EXIST
        public ServiceStatus Status { get; set; }
        public Guid DiscountId { get; set; }
        public Guid BranchId { get; set; }
    }
}