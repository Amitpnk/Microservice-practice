using Eventick.Services.EventtCatalog.Entities;

namespace Eventick.Services.EventtCatalog.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetEvents(Guid categoryId);
    Task<Event> GetEventById(Guid eventId);
}