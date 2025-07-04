using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ASP.NET_GROCERY_WEB_APP.Models;

namespace ASP.NET_GROCERY_WEB_APP.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private GroceryDbContext db = new GroceryDbContext();

        // ✅ GET: /Orders/Checkout
        public ActionResult Checkout()
        {
            var userId = User.Identity.GetUserId();

            var cartItems = db.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToList();

            if (!cartItems.Any())
            {
                TempData["Message"] = "Your cart is empty.";
                return RedirectToAction("Index", "Products");
            }

            return View(cartItems); // Expects Views/Orders/Checkout.cshtml
        }

        // ✅ POST: /Orders/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(string customerName, string phoneNumber, string address, int? rating, string review)
        {
            var userId = User.Identity.GetUserId();

            var cartItems = db.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToList();

            if (!cartItems.Any())
            {
                TempData["Message"] = "Your cart is empty.";
                return RedirectToAction("Index", "Products");
            }

            // Create Order
            var order = new Order
            {
                UserId = userId,
                CustomerName = customerName,
                PhoneNumber = phoneNumber,
                Address = address,
                Rating = rating,
                Review = review,
                OrderDate = DateTime.Now,
                TotalAmount = cartItems.Sum(c => c.Product.Price * c.Quantity),
                Items = cartItems.Select(c => new OrderItem
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    Price = c.Product.Price
                }).ToList()
            };

            db.Orders.Add(order);
            db.CartItems.RemoveRange(cartItems); // Clear the cart
            db.SaveChanges();

            return RedirectToAction("Success");
        }

        // ✅ GET: /Orders/Success
        public ActionResult Success()
        {
            ViewBag.Message = "🎉 Your order has been placed successfully!";
            return View();
        }

        // ✅ GET: /Orders/History
        public ActionResult History()
        {
            var userId = User.Identity.GetUserId();

            var orders = db.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items.Select(i => i.Product))
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return View(orders); // Views/Orders/History.cshtml
        }
    }
}
