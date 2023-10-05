using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Solares.Data;
using Solares.Models;

namespace Solares.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("OMAR$ADM�IN$Acc$sess")]
    public class LocalizationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Localizations
        public async Task<IActionResult> Index()
        {
              return View(await _context.Localization.ToListAsync());
        }

        // GET: Admin/Localizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Localization == null)
            {
                return NotFound();
            }

            var localization = await _context.Localization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localization == null)
            {
                return NotFound();
            }

            return View(localization);
        }

        // GET: Admin/Localizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Localizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,active")] Localization localization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localization);
        }

        // GET: Admin/Localizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Localization == null)
            {
                return NotFound();
            }

            var localization = await _context.Localization.FindAsync(id);
            if (localization == null)
            {
                return NotFound();
            }
            return View(localization);
        }

        // POST: Admin/Localizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,active")] Localization localization)
        {
            id = 1;
            if (id != localization.Id)
            {
                return NotFound();
            }

                try
                {
                if (localization.active==true)
                {
                    localization.active = false;
                }
                else
                {
                    localization.active = true;
                }
                    _context.Update(localization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizationExists(localization.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            return RedirectToAction("Index", "Home", new { area = "Customer" });

        }

        // GET: Admin/Localizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Localization == null)
            {
                return NotFound();
            }

            var localization = await _context.Localization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localization == null)
            {
                return NotFound();
            }

            return View(localization);
        }

        // POST: Admin/Localizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Localization == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Localization'  is null.");
            }
            var localization = await _context.Localization.FindAsync(id);
            if (localization != null)
            {
                _context.Localization.Remove(localization);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalizationExists(int id)
        {
          return _context.Localization.Any(e => e.Id == id);
        }
    }
}
