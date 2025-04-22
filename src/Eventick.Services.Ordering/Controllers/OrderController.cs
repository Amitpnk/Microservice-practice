using Eventick.Services.Ordering.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Eventick.Services.Ordering.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> List(Guid userId)
    {
        var orders = await _orderRepository.GetOrdersForUser(userId);
        return Ok(orders);
    }
}