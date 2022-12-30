namespace apiForVisualRiders.Models
{
    public enum CompanyStatus
    {
        Active,
        Inactive
    }
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ActiveSince { get; set; }

        public string LegalCompanyName { get; set; }

        public string BillingDetails { get; set; }

        public CompanyStatus Status { get; set; }
    }
}

