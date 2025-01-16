using CoffeeShopMVC.Data;
using CoffeeShopMVC.Extensions;
using CoffeeShopMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopMVC.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Orders/CreateOrder
        [HttpGet]
        public IActionResult CreateOrder()
        {

            return View();
        }

        // POST: /Orders/CreateOrder
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CustomerInfo info)
        {
            if (!ModelState.IsValid)
            {
                return View(info);
            }

            _context.CustomerInfos.Add(info);
            await _context.SaveChangesAsync();

            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart")
                       ?? new List<CartItem>();
            if (cart.Count == 0)
            {

                ModelState.AddModelError("", "Koszyk jest pusty.");
                return View(info);
            }


            var userId = _userManager.GetUserId(User);
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                CustomerInfoId = info.CustomerInfoId,
                OrderItems = new List<OrderItem>(),
                TotalPrice = 0
            };

            decimal total = 0;
            foreach (var item in cart)
            {
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                };
                total += item.Price * item.Quantity;
                order.OrderItems.Add(orderItem);
            }
            order.TotalPrice = total;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Details", new { id = order.OrderId });
        }

        // GET: /Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.CustomerInfo)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null) return NotFound();


            return View(order);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminIndex()
        {
            var orders = await _context.Orders
                .Include(o => o.CustomerInfo)
                .Include(o => o.OrderItems)
                .ToListAsync();

            return View(orders);
        }
    }
}