using System.Threading.Tasks;
using Invoice_Management_System.Data;
using Invoice_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Management_System.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurrencyController(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<IActionResult> Index()
        {
            return View(await _context.Currencies.ToListAsync());
        }

        //Get - Create
        public ActionResult Create()
        {
            return View();
        }

        //Post - Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Currency currency)
        {
            if (ModelState.IsValid)
            {
                _context.Currencies.Add(currency);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }

        //Get - Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencies.FindAsync(id);

            if (currency == null)
            {
                return NotFound();
            }
            return View(currency);
        }

        //Get - Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencies.FindAsync(id);

            if (currency == null)
            {
                return NotFound();
            }
            return View(currency);
        }

        //Post - Edit

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(Currency currency)
        {
            if (ModelState.IsValid)
            {
                _context.Currencies.Update(currency);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }

        //Get - Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencies.FindAsync(id);

            if (currency == null)
            {
                return NotFound();
            }
            return View(currency);
        }

        //Post - Delete

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var currency = await _context.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }
            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
