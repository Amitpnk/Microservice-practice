using Eventick.Web.Models.Api;
using System.Collections.Generic;

namespace Eventick.Web.Models.View
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
