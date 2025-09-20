Stripe Payment Integration Setup Guide
This document will guide you through setting up and running this .NET application to process payments with Stripe.

1. Sign Up for a Stripe Account
First, you need a Stripe account.

Go to dashboard.stripe.com/register and create an account.

Complete the account activation steps. For testing, you don't need to provide real bank details yet.

2. Get Your API Keys
Stripe provides two sets of keys: one for testing ("Test mode") and one for real payments ("Live mode"). We will use the test keys for development.

Log in to your Stripe Dashboard.

Make sure the Test mode toggle is enabled in the top-right corner.

Go to the Developers section in the top-right menu, then click on API keys.

You will see two keys on this page:

Publishable key: This key is safe to use in front-end code (like in JavaScript). It starts with pk_test_....

Secret key: This key is for your server-side code only. Never share it publicly. It starts with sk_test_.... Click "Reveal test key" to see it.

3. Configure the Application
Now, you need to add these keys to your .NET project.

Open the Solution in Visual Studio.

In the Solution Explorer, find and open the appsettings.json file.

You will see the following Stripe section:

"Stripe": {
  "PublishableKey": "YOUR_STRIPE_PUBLISHABLE_KEY",
  "SecretKey": "YOUR_STRIPE_SECRET_KEY"
}

Replace the placeholders:

Paste your Publishable key in place of YOUR_STRIPE_PUBLISHABLE_KEY.

Paste your Secret key in place of YOUR_STRIPE_SECRET_KEY.

Save the appsettings.json file.

Security Note: The appsettings.json file is suitable for local development. For a production application, you should use a more secure method to store secrets, such as the .NET Secret Manager or Azure Key Vault.

4. Run the Application
Press F5 or click the "Start Debugging" button (▶) in Visual Studio.

A browser window will open to the checkout page, showing a product.

Click the "Pay with Stripe" button.

You will be redirected to a secure, Stripe-hosted payment page.

5. Use Stripe's Test Cards
On the Stripe payment page, you can use special test card numbers to simulate different payment scenarios.

For a successful payment: Use the card number 4242 4242 4242 4242, any future expiration date (e.g., 12/29), and any 3-digit CVC (e.g., 123).

For a failed payment: You can find other test card numbers in the Stripe documentation.

After completing the payment, Stripe will redirect you back to either the /Checkout/Success or /Checkout/Cancel page in your application.

You have now successfully integrated a secure payment gateway!