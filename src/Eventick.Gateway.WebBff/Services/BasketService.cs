using Eventick.Gateway.Shared.Basket;
using Eventick.Gateway.WebBff.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eventick.Gateway.WebBff.Services;

public class BasketService : IBasketService
{
    private readonly HttpClient client;

    public BasketService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<BasketDto> GetBasket(Guid basketId)
    {
        if (basketId == Guid.Empty)
            return null;
        var response = await client.GetAsync($"/api/baskets/{basketId}");
        return await response.ReadContentAs<BasketDto>();
    }
}