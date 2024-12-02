using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly SanPhamDbcontext _context = new SanPhamDbcontext();

        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public ActionResult ProductDetails(Guid id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }
    }
}
