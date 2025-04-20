using System;
using System.Threading.Tasks;
using Eventick.Services.ShoppingBasket.Entities;

namespace Eventick.Services.ShoppingBasket.Services
{
    public interface IEventCatalogService
    {
        Task<Event> GetEvent(Guid id);
    }
}