﻿using System;

namespace Eventick.Services.ShoppingBasket.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
