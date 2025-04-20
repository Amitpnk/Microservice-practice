using Eventick.Services.EventCatalog.Entities;

namespace Eventick.Services.EventCatalog.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetEvents(Guid categoryId);
    Task<Event> GetEventById(Guid eventId);
}