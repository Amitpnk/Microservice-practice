using Eventick.Integration.MessagingBus;
using Eventick.Services.Payment.Services;
using Eventick.Services.Payment.Worker;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// Add services to the container.
services.AddHostedService<ServiceBusListener>();
services.AddHttpClient<IExternalGatewayPaymentService, ExternalGatewayPaymentService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:ExternalPaymentGateway:Uri"] ?? string.Empty));

services.Configure<ServiceBusSettings>(builder.Configuration.GetSection(ServiceBusSettings.SectionName));
services.AddSingleton<IMessageBus, AzServiceBusMessageBus>();

services.AddSwaggerGen();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

Console.Title = "Payment";
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
