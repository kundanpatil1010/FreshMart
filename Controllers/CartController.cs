using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ASP.NET_GROCERY_WEB_APP.Models;

[Authorize]
public class CartController : Controller
{
    GroceryDbContext db = new GroceryDbContext();

    // GET: /Cart/
    public ActionResult Index()
    {
        string userId = User.Identity.GetUserId();

        var cartItems = db.CartItems
            .Include("Product")
            .Where(c => c.UserId == userId)
            .ToList();

        return View(cartItems);
    }

    // POST: /Cart/Add (AJAX)
    [HttpPost]
    public ActionResult Add(int id)
    {
        var userId = User.Identity.GetUserId();
        var item = db.CartItems.FirstOrDefault(c => c.UserId == userId && c.ProductId == id);

        if (item != null)
            item.Quantity++;
        else
            db.CartItems.Add(new CartItem { UserId = userId, ProductId = id, Quantity = 1 });

        db.SaveChanges();
        return Json(new { success = true });
    }

    // ✅ POST: /Cart/RemoveViaAjax (for jQuery AJAX)
    [HttpPost]
    public ActionResult RemoveViaAjax(int id)
    {
        var userId = User.Identity.GetUserId();
        var item = db.CartItems.FirstOrDefault(c => c.UserId == userId && c.ProductId == id);

        if (item != null)
        {
            db.CartItems.Remove(item);
            db.SaveChanges();
        }

        return Json(new { success = true });
    }

    // ✅ GET: /Cart/Remove/20 (from <a href>)
    [HttpGet]
    public ActionResult Remove(int id)
    {
        var userId = User.Identity.GetUserId();
        var item = db.CartItems.FirstOrDefault(c => c.CartItemId == id && c.UserId == userId);

        if (item != null)
        {
            db.CartItems.Remove(item);
            db.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    // POST: /Cart/AddToCart (used by some forms)
    [HttpPost]
    public ActionResult AddToCart(int productId)
    {
        string userId = User.Identity.GetUserId();

        var existingCartItem = db.CartItems.FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);

        if (existingCartItem != null)
        {
            existingCartItem.Quantity += 1;
        }
        else
        {
            db.CartItems.Add(new CartItem
            {
                ProductId = productId,
                UserId = userId,
                Quantity = 1
            });
        }

        db.SaveChanges();
        return RedirectToAction("Index", "Cart");
    }
    [HttpPost]
    public ActionResult AddMultiple(int id, int quantity)
    {
        var userId = User.Identity.GetUserId();
        var item = db.CartItems.FirstOrDefault(c => c.UserId == userId && c.ProductId == id);

        if (item != null)
            item.Quantity += quantity;
        else
            db.CartItems.Add(new CartItem { UserId = userId, ProductId = id, Quantity = quantity });

        db.SaveChanges();
        return Json(new { success = true });
    }
    [HttpPost]
    public ActionResult UpdateQuantity(int id, int quantity)
    {
        var userId = User.Identity.GetUserId();
        var item = db.CartItems.FirstOrDefault(c => c.CartItemId == id && c.UserId == userId);

        if (item != null && quantity > 0)
        {
            item.Quantity = quantity;
            db.SaveChanges();
        }

        return new HttpStatusCodeResult(200);
    }

}
