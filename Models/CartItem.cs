using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_GROCERY_WEB_APP.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

    }
}