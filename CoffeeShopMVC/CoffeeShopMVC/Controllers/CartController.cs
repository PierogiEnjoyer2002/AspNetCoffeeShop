using CoffeeShopMVC.Data;
using CoffeeShopMVC.Extensions;
using CoffeeShopMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Cart/Index
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetObject<List<CartItem>>("Cart")
                                  ?? new List<CartItem>();
            return View(cart);
        }

        // GET: /Cart/AddToCart?productId=5
        public IActionResult AddToCart(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return NotFound();
            }

            List<CartItem> cart = HttpContext.Session.GetObject<List<CartItem>>("Cart")
                                  ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(x => x.ProductId == productId);
            if (existingItem == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                existingItem.Quantity++;
            }

            HttpContext.Session.SetObject("Cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItem(int productId)
        {
            List<CartItem> cart = HttpContext.Session.GetObject<List<CartItem>>("Cart")
                                  ?? new List<CartItem>();

            var item = cart.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
            }

            HttpContext.Session.SetObject("Cart", cart);
            return RedirectToAction("Index");
        }
    }
}