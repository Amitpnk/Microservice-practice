using Eventick.Gateway.WebBff.Services;
using Eventick.Gateway.WebBff.Url;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddControllers();

services.AddOptions();
services.Configure<ServiceUrls>(configuration.GetSection("ServiceUrls"));

services.AddHttpClient<ICatalogService, CatalogService>(c =>
    c.BaseAddress = new Uri(configuration["ServiceUrls:EventCatalog"]));

services.AddHttpClient<IBasketService, BasketService>(c =>
    c.BaseAddress = new Uri(configuration["ServiceUrls:ShoppingBasket"]));

services.AddHttpClient<IDiscountService, DiscountService>(c =>
    c.BaseAddress = new Uri(configuration["ServiceUrls:Discount"]));

services.AddHttpClient<IOrderService, OrderService>(c =>
    c.BaseAddress = new Uri(configuration["ServiceUrls:Ordering"]));

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Swagger"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();