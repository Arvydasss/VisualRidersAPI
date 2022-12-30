namespace APIforVisualRiders.Models
{
    public class ItemCategory
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid Discount { get; set; }
    }
}
