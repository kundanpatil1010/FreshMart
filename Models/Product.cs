using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_GROCERY_WEB_APP.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}