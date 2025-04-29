using AutoMapper;
using Eventick.Services.ShoppingBasket.Entities;
using Eventick.Services.ShoppingBasket.Models;

namespace Eventick.Services.ShoppingBasket.Profiles
{
    public class BasketChangeEventProfile: Profile
    {
        public BasketChangeEventProfile()
        {
            CreateMap<BasketChangeEvent, BasketChangeEventForPublication>().ReverseMap();
        }
    }
}
