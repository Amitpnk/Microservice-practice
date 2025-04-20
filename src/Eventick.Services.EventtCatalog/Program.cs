using Eventick.Services.EventtCatalog.DbContexts;
using Eventick.Services.EventtCatalog.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EventCatalogDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Version = "9.9";
        document.Info.Title = "Demo .NET 9 API";
        document.Info.Description = "This API demonstrates OpenAPI customization in a .NET 9 project.";
        document.Info.TermsOfService = new Uri("https://codewithmukesh.com/terms");
        document.Info.Contact = new OpenApiContact
        {
            Name = "Mukesh Murugan",
            Email = "mukesh@codewithmukesh.com",
            Url = new Uri("https://codewithmukesh.com")
        };
        document.Info.License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        };
        return Task.CompletedTask;
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EventCatalogDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{  
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Swagger"));


    //app.MapScalarApiReference(options =>
    //{
    //    options
    //    .WithTheme(ScalarTheme.Kepler)
    //    .WithDarkModeToggle(true)
    //    .WithClientButton(true);
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();