using QuickBite.Application.Interfaces;
using QuickBite.Application.Orchestrators;
using QuickBite.Infrastructure.Payments;
using QuickBite.Infrastructure.Restaurants;
using QuickBite.Infrastructure.Drivers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IPaymentService, MockPaymentService>();
builder.Services.AddScoped<IRestaurantService, MockRestaurantService>();
builder.Services.AddScoped<IDriverService, MockDriverService>();

builder.Services.AddScoped<KitchenOrchestrator>();
builder.Services.AddScoped<DriverMatcher>();
builder.Services.AddScoped<OrderProcessingEngine>();

var app = builder.Build();
app.MapControllers();
app.Run();
