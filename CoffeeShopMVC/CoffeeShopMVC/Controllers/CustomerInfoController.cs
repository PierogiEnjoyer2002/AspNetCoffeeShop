using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShopMVC.Data;
using CoffeeShopMVC.Models;

namespace CoffeeShopMVC.Controllers
{
    public class CustomerInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerInfos.ToListAsync());
        }

        // GET: CustomerInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInfo = await _context.CustomerInfos
                .FirstOrDefaultAsync(m => m.CustomerInfoId == id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            return View(customerInfo);
        }

        // GET: CustomerInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerInfoId,FirstName,LastName,Phone,DeliveryAddress")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerInfo);
        }

        // GET: CustomerInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInfo = await _context.CustomerInfos.FindAsync(id);
            if (customerInfo == null)
            {
                return NotFound();
            }
            return View(customerInfo);
        }

        // POST: CustomerInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerInfoId,FirstName,LastName,Phone,DeliveryAddress")] CustomerInfo customerInfo)
        {
            if (id != customerInfo.CustomerInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerInfoExists(customerInfo.CustomerInfoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customerInfo);
        }

        // GET: CustomerInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInfo = await _context.CustomerInfos
                .FirstOrDefaultAsync(m => m.CustomerInfoId == id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            return View(customerInfo);
        }

        // POST: CustomerInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerInfo = await _context.CustomerInfos.FindAsync(id);
            if (customerInfo != null)
            {
                _context.CustomerInfos.Remove(customerInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerInfoExists(int id)
        {
            return _context.CustomerInfos.Any(e => e.CustomerInfoId == id);
        }
    }
}
