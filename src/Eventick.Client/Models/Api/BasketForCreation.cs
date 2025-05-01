using System;
using System.ComponentModel.DataAnnotations;

namespace Eventick.Web.Models.Api
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
