using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventick.Services.Marketing.Models;

namespace Eventick.Services.Marketing.Services
{
    public interface IBasketChangeEventService
    {
        Task<List<BasketChangeEvent>> GetBasketChangeEvents(DateTime startDate, int max);
    }
}