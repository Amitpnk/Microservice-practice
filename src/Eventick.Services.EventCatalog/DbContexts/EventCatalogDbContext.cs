using Eventick.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Eventick.Services.EventCatalog.DbContexts;

public class EventCatalogDbContext : DbContext
{
    public EventCatalogDbContext(DbContextOptions<EventCatalogDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        //todo: convert to use the new JSON file format

        // Load categories from JSON
        //var categoriesJson = File.ReadAllText("SeedData/categories.json");
        //var categories = JsonSerializer.Deserialize<List<Category>>(categoriesJson);
        //modelBuilder.Entity<Category>().HasData(categories);

        //Console.WriteLine($"Base Directory: {AppContext.BaseDirectory}");
        //Console.WriteLine($"Looking for: {Path.Combine(AppContext.BaseDirectory, "SeedData", "categories.json")}");
        //Console.WriteLine($"Looking for: {"SeedData/categories.json"}");

        //var categoriesJson = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "..", "..",  "SeedData", "categories.json"));
        //var categories = JsonSerializer.Deserialize<List<Category>>(categoriesJson);
        //modelBuilder.Entity<Category>().HasData(categories);

        //// Load events from JSON
        //var eventsJson = File.ReadAllText("SeedData/events.json");
        //var events = JsonSerializer.Deserialize<List<Event>>(eventsJson);
        //modelBuilder.Entity<Event>().HasData(events);


        var concertGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA314}");
        var musicalGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA315}");
        var playGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA316}");


        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = concertGuid,
            Name = "Concerts"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = musicalGuid,
            Name = "Musicals"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = playGuid,
            Name = "Plays"
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA317}"),
            Name = "Arijit Singh Live in Concert",
            Price = 4500, 
            Artist = "Arijit Singh",
            Date = new DateTime(2025, 10, 1),
            Description = "Join India's most beloved playback singer Arijit Singh for his farewell tour across 15 Indian cities. Experience the magic of his soulful voice live.",
            ImageUrl = "/img/arijit.jpg",
            CategoryId = concertGuid
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA319}"),
            Name = "Comedy Night with Kapil Sharma",
            Price = 3500,
            Artist = "Kapil Sharma",
            Date = new DateTime(2026, 1, 1),
            Description = "India's comedy king Kapil Sharma brings his hilarious team for a live show that will leave you in splits. Featuring Sunil Grover, Krushna Abhishek and other special guests!",
            ImageUrl = "/img/kapil.jpg",
            CategoryId = concertGuid
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA318}"),
            Name = "Bharat: The Musical",
            Price = 3000, 
            Artist = "Shankar Mahadevan",
            Date = new DateTime(2025, 12, 1),
            Description = "Experience this spectacular musical journey through India's history, composed by Shankar Mahadevan. The show has received rave reviews from critics and audiences alike.",
            ImageUrl = "/img/musical.jpg",
            CategoryId = musicalGuid
        });

    }
}