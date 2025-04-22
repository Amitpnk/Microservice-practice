using Eventick.Services.Ordering.Entities;

namespace Eventick.Services.Ordering.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersForUser(Guid userId);
    Task AddOrder(Order order);
    Task<Order> GetOrderById(Guid orderId);
    Task UpdateOrderPaymentStatus(Guid orderId, bool paid);

}