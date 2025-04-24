using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventick.Gateway.Shared.Event;
using Eventick.Gateway.WebBff.Models;

namespace Eventick.Gateway.WebBff.Services;

public interface ICatalogService
{
    Task<List<EventDto>> GetEventsPerCategory(Guid categoryId);
    Task<EventDto> GetEventById(Guid eventId);

    Task<List<CategoryDto>> GetAllCategories();
    Task<List<EventDto>> GetAllEvents();
}