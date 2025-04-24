using Eventick.Gateway.Shared.Basket;
using System;
using System.Threading.Tasks;

namespace Eventick.Gateway.WebBff.Services
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasket(Guid basketId);
    }
}