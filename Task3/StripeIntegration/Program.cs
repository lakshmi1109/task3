using Microsoft.Extensions.Options;
using Stripe;
using StripeIntegration.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Configure Stripe settings from appsettings.json
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 2. Set the global Stripe API key
// We retrieve the StripeSettings using dependency injection to get the secret key.
var stripeSettings = app.Services.GetRequiredService<IOptions<StripeSettings>>().Value;
StripeConfiguration.ApiKey = stripeSettings.SecretKey;


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Checkout}/{action=Index}/{id?}");

app.Run();
