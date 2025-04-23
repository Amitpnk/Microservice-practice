using Eventick.Services.Marketing.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventick.Services.Marketing.DbContexts
{
    public class MarketingDbContext:  DbContext
    {
    public MarketingDbContext(DbContextOptions<MarketingDbContext> options)
        : base(options)
    {
    }

    public DbSet<BasketChangeEvent> BasketChangeEvents { get; set; }
}
}
