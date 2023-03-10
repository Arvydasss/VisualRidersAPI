namespace apiForVisualRiders.Models
{
    public enum DiscountMeasure
    {
        Percentage,
        Absolute
    }

    public class Discount
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DiscountMeasure Measure { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}