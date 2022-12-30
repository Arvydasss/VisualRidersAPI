namespace APIforVisualRiders.Models
{
    public enum OrderStatus
    {
        Created,
        Returned,
        Completed,
        Cancelled, 
        Refunded
    }

    public class Order
    {
        public Guid Id { get; set; }

        public DateTime SubmissionDate { get; set; }

        public DateTime? FulfillmentDate { get; set; }

        public decimal Tip { get; set; }

        // public bool RequiresDelivery { get; set; }

        public string? Comment { get; set; }

        public OrderStatus? Status { get; set; }

        public Guid Customer { get; set; }

        public Guid Employee { get; set; }

        public Guid Discount { get; set; }

        public Guid Delivery { get; set; }

        public OrderItem? OrderItem { get; set; }

    }
}
