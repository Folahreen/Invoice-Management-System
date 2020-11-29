using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Management_System.Data;
using Invoice_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Management_System.Controllers
{
    public class ExchangeRatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExchangeRatesController(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExchangeRate.ToListAsync());
        }

        //Get - Create
        public ActionResult Create()
        {
            return View();
        }

        //Post - Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                _context.ExchangeRate.Add(exchangeRate);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(exchangeRate);
        }

        //Get - Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRate.FindAsync(id);

            if (exchangeRate == null)
            {
                return NotFound();
            }
            return View(exchangeRate);
        }

        //Get - Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRate.FindAsync(id);

            if (exchangeRate == null)
            {
                return NotFound();
            }
            return View(exchangeRate);
        }

        //Post - Edit

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                _context.ExchangeRate.Update(exchangeRate);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(exchangeRate);
        }

        //Get - Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRate.FindAsync(id);

            if (exchangeRate == null)
            {
                return NotFound();
            }
            return View(exchangeRate);
        }

        //Post - Delete

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var exchangeRate = await _context.ExchangeRate.FindAsync(id);
            if (exchangeRate == null)
            {
                return NotFound();
            }
            _context.ExchangeRate.Remove(exchangeRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
