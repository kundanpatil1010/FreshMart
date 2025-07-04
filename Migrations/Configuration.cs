namespace ASP.NET_GROCERY_WEB_APP.Migrations
{
    using ASP.NET_GROCERY_WEB_APP.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ASP.NET_GROCERY_WEB_APP.Models.GroceryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ASP.NET_GROCERY_WEB_APP.Models.GroceryDbContext context)
        {
            // Step 1: Seed Categories
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new List<Category>
        {
            new Category { Name = "Fruits" },     // ID = 1
            new Category { Name = "Vegetables" }  // ID = 2
        });
                context.SaveChanges();
            }

            // Step 2: Seed Products
            if (!context.Products.Any())
            {
                var products = new List<Product>
        {
            new Product { Name = "Apple", ImageUrl = "/Images/apple.jpg", Price = 30, IsAvailable = true, CategoryId = 1 },
            new Product { Name = "Banana", ImageUrl = "/Images/banana.jpg", Price = 20, IsAvailable = true, CategoryId = 1 },
            new Product { Name = "Cabbage", ImageUrl = "/Images/cabbage.jpg", Price = 15, IsAvailable = true, CategoryId = 2 },
            new Product { Name = "Carrot", ImageUrl = "/Images/carrot.jpg", Price = 18, IsAvailable = true, CategoryId = 2 },
            new Product { Name = "Grapes", ImageUrl = "/Images/grapes.jpg", Price = 50, IsAvailable = true, CategoryId = 1 },
            new Product { Name = "Onion", ImageUrl = "/Images/onion.jpg", Price = 25, IsAvailable = true, CategoryId = 2 },
            new Product { Name = "Orange", ImageUrl = "/Images/orange.jpg", Price = 35, IsAvailable = true, CategoryId = 1 },
            new Product { Name = "Potato", ImageUrl = "/Images/potato.jpg", Price = 22, IsAvailable = true, CategoryId = 2 },
            new Product { Name = "Strawberry", ImageUrl = "/Images/strawberry.jpg", Price = 60, IsAvailable = true, CategoryId = 1 },
            new Product { Name = "Tomato", ImageUrl = "/Images/tomato.jpg", Price = 20, IsAvailable = true, CategoryId = 2 }
        };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }

    }
}