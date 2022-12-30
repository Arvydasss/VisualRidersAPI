namespace APIforVisualRiders.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public Guid Tax { get; set; }
    }
}
