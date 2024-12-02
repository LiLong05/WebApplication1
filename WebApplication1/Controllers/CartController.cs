using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        SanPhamDbcontext _db;
        public CartController(SanPhamDbcontext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Account"); // Chuyển hướng nếu chưa đăng nhập
            }

            var userId = Guid.Parse(userIdString);
            var cartItems = _db.Carts.Where(c => c.UserId == userId).ToList();
            return View(cartItems);
        }

        public ActionResult AddToCart(Guid productId, int quantity)
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = Guid.Parse(userIdString);
            var cartItem = new CartItem { ProductId = productId, Quantity = quantity, UserId = userId };
            _db.Carts.Add(cartItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
