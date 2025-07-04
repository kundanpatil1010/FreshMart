using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ASP.NET_GROCERY_WEB_APP.Models;


namespace ASP.NET_GROCERY_WEB_APP.Models
{
    public class GroceryDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public GroceryDbContext() : base("DefaultConnection") { }

        public static GroceryDbContext Create() => new GroceryDbContext();
    }

}