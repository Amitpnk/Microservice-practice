using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.Json;
using Eventick.Services.Discount.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventick.Services.Discount.DbContexts
{
    public class DiscountDbContext : DbContext
    {
        private readonly ILogger<DiscountDbContext> _logger;

        public DiscountDbContext(DbContextOptions<DiscountDbContext> options, ILogger<DiscountDbContext> logger) : base(options)
        {
            _logger = logger;
        }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var filePath = Path.Combine(AppContext.BaseDirectory, "DbContexts/SeedData", "discounts.json");
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                var coupons = JsonSerializer.Deserialize<List<Coupon>>(jsonData);

                if (coupons != null)
                {
                    modelBuilder.Entity<Coupon>().HasData(coupons);
                }
            }


            // Load categories from JSON
            //var coupons = LoadSeedData<Coupon>("discounts.json");
            //if (coupons != null)
            //{
            //    modelBuilder.Entity<Coupon>().HasData(coupons);
            //}

            //modelBuilder.Entity<Coupon>().HasData(new Coupon
            //{
            //    CouponId = Guid.NewGuid(),
            //    Code = "BeNice",
            //    Amount = 10,
            //    AlreadyUsed = false
            //});

            //modelBuilder.Entity<Coupon>().HasData(new Coupon
            //{
            //    CouponId = Guid.NewGuid(),
            //    Code = "Awesome",
            //    Amount = 20,
            //    AlreadyUsed = false
            //});

            //modelBuilder.Entity<Coupon>().HasData(new Coupon
            //{
            //    CouponId = Guid.NewGuid(),
            //    Code = "AlmostFree",
            //    Amount = 100,
            //    AlreadyUsed = false
            //});

        }

        //todo : move this to cross-cutting layer
        private List<T> LoadSeedData<T>(string fileName)
        {
            try
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "DbContexts/SeedData", fileName);
                if (!File.Exists(filePath))
                {
                    _logger.LogWarning("Seed data file not found: {FilePath}", filePath);
                    return null;
                }

                var jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<T>>(jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading seed data from {FileName}", fileName);
                return null;
            }
        }
    }
}
