using System.ComponentModel.DataAnnotations;

namespace Eventick.Services.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
