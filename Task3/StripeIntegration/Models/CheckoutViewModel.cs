namespace StripeIntegration.Models
{
    public class CheckoutViewModel
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public long ProductPrice { get; set; } // Price in smallest currency unit (e.g., cents)
        public string ProductCurrency { get; set; } // e.g., "usd", "inr"
        public string PublishableKey { get; set; }
    }
}
