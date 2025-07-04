using System;
using System.Collections.Generic;

namespace ASP.NET_GROCERY_WEB_APP.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Address { get; set; }

        public string CustomerName { get; set; }

        public string PhoneNumber { get; set; }

        public int? Rating { get; set; }

        public string Review { get; set; }

        public decimal TotalAmount { get; set; } // ✅ Newly added for tracking order cost

        public virtual ICollection<OrderItem> Items { get; set; } // ✅ Navigation
    }
}
