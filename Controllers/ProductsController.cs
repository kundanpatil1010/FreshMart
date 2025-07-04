using ASP.NET_GROCERY_WEB_APP.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

public class ProductsController : Controller
{
    GroceryDbContext db = new GroceryDbContext();

    public ActionResult Index(int? categoryId)
    {
        var userId = User.Identity.GetUserId();

        if (!string.IsNullOrEmpty(userId))
        {
            var cartCount = db.CartItems
                .Where(c => c.UserId == userId)
                .Sum(c => (int?)c.Quantity) ?? 0;
            ViewBag.CartCount = cartCount;
        }
        else
        {
            ViewBag.CartCount = 0;
        }

        var categories = db.Categories.ToList();
        ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");

        var products = db.Products
            .Include("Category")
            .Where(p => p.IsAvailable);

        if (categoryId.HasValue)
            products = products.Where(p => p.CategoryId == categoryId);

        return View(products.ToList());
    }

    public JsonResult Search(string term)
    {
        var results = db.Products
            .Where(p => p.Name.Contains(term))
            .Select(p => new
            {
                p.ProductId,
                p.Name,
                p.Price,
                p.ImageUrl
            })
            .ToList();

        return Json(results, JsonRequestBehavior.AllowGet);
    }
}
