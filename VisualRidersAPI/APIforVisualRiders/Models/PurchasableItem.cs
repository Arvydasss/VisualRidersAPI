namespace APIforVisualRiders.Models
{
    public enum PurchasableItemStatus
    {
        Deleted,
        Active
    }
    public class PurchasableItem
    {

        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Duration { get; set; }

        public PurchasableItemStatus? Status { get; set; }

        public Guid? ItemCategory { get; set; }

        public Guid? Discount { get; set; }

    }
}
