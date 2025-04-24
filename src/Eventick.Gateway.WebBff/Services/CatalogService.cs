using Eventick.Gateway.Shared.Event;
using Eventick.Gateway.WebBff.Extensions;
using Eventick.Gateway.WebBff.Models;
using Eventick.Gateway.WebBff.Url;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eventick.Gateway.WebBff.Services
{
    public class CatalogService: ICatalogService
    {
        private readonly HttpClient client;

        public CatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<EventDto>> GetAllEvents()
        {
            var response = await client.GetAsync(EventCatalogOperations.GetAllEvents());
            return await response.ReadContentAs<List<EventDto>>();
        }

        public async Task<List<EventDto>> GetEventsPerCategory(Guid categoryId)
        {
            var response = await client.GetAsync(EventCatalogOperations.GetEventsPerCategory(categoryId));
            return await response.ReadContentAs<List<EventDto>>();
        }

        public async Task<EventDto> GetEventById(Guid eventId)
        {
            var response = await client.GetAsync(EventCatalogOperations.GetEventById(eventId));
            return await response.ReadContentAs<EventDto>();
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var response = await client.GetAsync(EventCatalogOperations.GetAllcategories());
            return await response.ReadContentAs<List<CategoryDto>>();
        }

    
    }
}
