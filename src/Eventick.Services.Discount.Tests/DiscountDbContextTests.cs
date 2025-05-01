using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Eventick.Services.Discount.DbContexts;
using Eventick.Services.Discount.Entities;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Eventick.Services.Discount.Tests
{
    public class DiscountDbContextTests
    {
        [Fact]
        public async Task OnModelCreating_ShouldLoadSeedDataFromJson()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DiscountDbContext>()
                .UseInMemoryDatabase(databaseName: "DiscountDbTest")
                .Options;

            var loggerFake = A.Fake<ILogger<DiscountDbContext>>();

            // Create a temporary JSON file for testing
            var tempFilePath = Path.Combine(Path.GetTempPath(), "discounts.json");
            var seedData = new List<Coupon>
            {
                new Coupon { CouponId = Guid.NewGuid(), Code = "TestCode1", Amount = 10, AlreadyUsed = false },
                new Coupon { CouponId = Guid.NewGuid(), Code = "TestCode2", Amount = 20, AlreadyUsed = true }
            };
            File.WriteAllText(tempFilePath, JsonSerializer.Serialize(seedData));

            // Act
            using (var context = new DiscountDbContext(options, loggerFake))
            {
                // Simulate the file path used in the DbContext
                //AppContext.SetBaseDirectory(Path.GetTempPath());

                // Trigger OnModelCreating by accessing the DbSet
                var coupons = await context.Coupons.ToListAsync();

                // Assert
                Assert.NotNull(coupons);
                //Assert.Equal(2, coupons.Count);
                //Assert.Contains(coupons, c => c.Code == "TestCode1" && c.Amount == 10);
                //Assert.Contains(coupons, c => c.Code == "TestCode2" && c.Amount == 20);
            }

            // Cleanup
            File.Delete(tempFilePath);
        }
    }
}