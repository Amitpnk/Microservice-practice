using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Eventick.Services.ShoppingBasket.Models;
using Eventick.Services.ShoppingBasket.Repositories;

namespace Eventick.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("api/basketevent")]
    public class BasketChangeEventController : ControllerBase
    {
        private readonly IBasketChangeEventRepository basketChangeEventRepository;
        private readonly IMapper mapper;

        public BasketChangeEventController(IMapper mapper, IBasketChangeEventRepository basketChangeEventRepository)
        {
            this.mapper = mapper;
            this.basketChangeEventRepository = basketChangeEventRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents([FromQuery] DateTime fromDate, [FromQuery] int max)
        {
            var events = await basketChangeEventRepository.GetBasketChangeEvents(fromDate, max);
            return Ok(mapper.Map<List<BasketChangeEventForPublication>>(events));
        }
    }
}
