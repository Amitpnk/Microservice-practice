﻿using Eventick.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventick.Web.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersForUser(Guid userId);
        Task<Order> GetOrderDetails(Guid orderId);
    }
}
