﻿using Eventick.Services.ShoppingBasket.Entities;
using Eventick.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventick.Services.ShoppingBasket.DbContexts
{
    public class ShoppingBasketDbContext : DbContext
    {
        public ShoppingBasketDbContext(DbContextOptions<ShoppingBasketDbContext> options)
        : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketLine> BasketLines { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<BasketChangeEvent> BasketChangeEvents { get; set; }
    }
}
