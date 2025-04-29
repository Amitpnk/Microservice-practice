using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventick.Services.ShoppingBasket.Entities;

namespace Eventick.Services.ShoppingBasket.Repositories
{
    public interface IBasketChangeEventRepository
    {
        Task AddBasketEvent(BasketChangeEvent basketChangeEvent);
        Task<List<BasketChangeEvent>> GetBasketChangeEvents(DateTime startDate, int max);
    }
}
