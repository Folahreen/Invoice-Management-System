using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Management_System.Data;
using Invoice_Management_System.Models;
using Invoice_Management_System.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Management_System.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<IActionResult> Index(InvoiceModel model)
        {
            if (model.InvoiceDate == null)
            {
                return NotFound();
            }

            var retrieveInvoice = await _context.InvoiceModels
                .Where(i => i.InvoiceDate == model.InvoiceDate)
                .Include(e => e.Currency)
                .Include(e => e.ExchangeRate)
                .Include(e => e.Client).ToListAsync();

            return View(retrieveInvoice);
           
        }

        // Get - Retrieve
        public  IActionResult RetrieveInvoice()
        {
            return View();
        }


        //Get - Create
        public async Task<ActionResult> Create()
        {
            var model = new InvoiceViewModel()
            {
                CurrencyList = await _context.Currencies.ToListAsync(),
                ClientList = await _context.Clients.ToListAsync(),
                ExchangeList = await _context.ExchangeRate.ToListAsync(),
                Invoice = new InvoiceModel()
            };
            return View(model);
        }

        //Post - Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(InvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.InvoiceModels.Add(model.Invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var modelVM = new InvoiceViewModel()
            {
                CurrencyList = await _context.Currencies.ToListAsync(),
                ClientList = await _context.Clients.ToListAsync(),
                ExchangeList = await _context.ExchangeRate.ToListAsync(),
                Invoice = model.Invoice
            };
            return View(modelVM);
        }
    }
}
