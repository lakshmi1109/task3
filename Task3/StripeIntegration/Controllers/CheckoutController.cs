using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using StripeIntegration.Models;

namespace StripeIntegration.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly StripeSettings _stripeSettings;

        public CheckoutController(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
        }

        // This action displays the checkout page with the product info.
        public IActionResult Index()
        {
            var viewModel = new CheckoutViewModel
            {
                ProductName = "Premium Laptop Sleeve",
                ProductDescription = "Protect your laptop in style. Fits 15-inch laptops.",
                ProductPrice = 5000, // Price in the smallest currency unit (e.g., cents for USD, paise for INR)
                ProductCurrency = "inr", // Use "usd", "eur", "inr", etc.
                PublishableKey = _stripeSettings.PublishableKey
            };
            return View(viewModel);
        }

        // This action is called when the user clicks the "Pay with Stripe" button.
        // It creates a Stripe Checkout Session and redirects the user to Stripe's payment page.
        [HttpPost]
        public IActionResult CreateCheckoutSession(string productName, long productPrice, string productCurrency)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = productPrice,
                            Currency = productCurrency,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = productName,
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                // These URLs are where Stripe will redirect the user after the payment process.
                SuccessUrl = Url.Action("Success", "Checkout", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Checkout", null, Request.Scheme),
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Redirect(session.Url);
        }

        // This action is shown when the payment is successful.
        public IActionResult Success()
        {
            return View();
        }

        // This action is shown when the payment is canceled or fails.
        public IActionResult Cancel()
        {
            return View();
        }
    }
}
