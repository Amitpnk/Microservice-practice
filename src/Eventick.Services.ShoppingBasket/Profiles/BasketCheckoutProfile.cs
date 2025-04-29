using AutoMapper;
using Eventick.Services.ShoppingBasket.Messages;
using Eventick.Services.ShoppingBasket.Models;

namespace Eventick.Services.ShoppingBasket.Profiles
{
    public class BasketCheckoutProfile: Profile
    {
        public BasketCheckoutProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutMessage>().ReverseMap();
        }
    }
}
