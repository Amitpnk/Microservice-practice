using AutoMapper;
using Eventick.Services.Discount.Entities;
using Eventick.Services.Discount.Models;

namespace Eventick.Services.Discount.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
