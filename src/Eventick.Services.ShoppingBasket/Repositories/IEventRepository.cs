using System;
using System.Threading.Tasks;
using Eventick.Services.ShoppingBasket.Entities;

namespace Eventick.Services.ShoppingBasket.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(Event theEvent);
        Task<bool> EventExists(Guid eventId);
        Task<bool> SaveChanges();
    }
}