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
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        //Get - Create
        public ActionResult Create()
        {
            return View();
        }

        //Post - Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Clients clients)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(clients);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(clients);
        }

        //Get - Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        //Get - Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            
            if(client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        //Post - Edit

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(Clients clients)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Update(clients);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(clients);
        }

        //Get - Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        //Post - Delete

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if(client == null)
            {
                return NotFound();
            }
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
