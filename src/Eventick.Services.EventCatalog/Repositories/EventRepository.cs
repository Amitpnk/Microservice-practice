using Eventick.Services.EventCatalog.DbContexts;
using Eventick.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventick.Services.EventCatalog.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EventCatalogDbContext _eventCatalogDbContext;

    public EventRepository(EventCatalogDbContext eventCatalogDbContext)
    {
        _eventCatalogDbContext = eventCatalogDbContext;
    }


    public async Task<IEnumerable<Event>> GetEvents(Guid categoryId)
    {
        return await _eventCatalogDbContext.Events
            .Include(x => x.Category)
            .Where(x => x.CategoryId == categoryId || categoryId == Guid.Empty).ToListAsync();
    }

    public async Task<Event> GetEventById(Guid eventId)
    {
        return await _eventCatalogDbContext.Events.Include(x => x.Category).Where(x => x.EventId == eventId).FirstOrDefaultAsync();
    }
}