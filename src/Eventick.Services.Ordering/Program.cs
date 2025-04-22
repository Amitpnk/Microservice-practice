using Eventick.Services.Ordering.DbContexts;
using Eventick.Services.Ordering.Messaging;
using Eventick.Services.Ordering.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services= builder.Services;
// Add services to the container.
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

services.AddScoped<IOrderRepository, OrderRepository>();

//Specific DbContext for use from singleton AzServiceBusConsumer
var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

services.AddSingleton(new OrderRepository(optionsBuilder.Options));

services.AddSingleton<IMessageBus, AzServiceBusMessageBus>();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering API", Version = "v1" });
});

services.AddSingleton<IAzServiceBusConsumer, AzServiceBusConsumer>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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