using System;
using System.ComponentModel.DataAnnotations;

namespace Eventick.Web.Models.Api
{
    public class CouponForUpdate
    {
        [Required]
        public Guid CouponId { get; set; }
    }
}
