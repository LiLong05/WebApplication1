using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        SanPhamDbcontext _db;
        public AdminController(SanPhamDbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ManageProducts()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        public ActionResult EditProduct(Guid id)
        {
            var product = _db.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("ManageProducts");
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("ManageProducts");
        }

        public ActionResult ViewOrders()
        {
            var orders = _db.Orders.ToList();
            return View(orders);
        }
    }
}
