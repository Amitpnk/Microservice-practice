using System;
using System.Net.Http;
using System.Threading.Tasks;
using Eventick.Services.ShoppingBasket.Entities;
using Eventick.Services.ShoppingBasket.Extensions;

namespace Eventick.Services.ShoppingBasket.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient client;

        public EventCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await client.GetAsync($"/api/events/{id}");
            return await response.ReadContentAs<Event>();
        }
    }
}
