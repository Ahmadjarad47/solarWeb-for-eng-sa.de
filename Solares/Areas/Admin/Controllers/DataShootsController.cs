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
    public class DataShootsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataShootsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DataShoots
        public async Task<IActionResult> Index()
        {
              return View(await _context.DataShoot.ToListAsync());
        }

        // GET: Admin/DataShoots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DataShoot == null)
            {
                return NotFound();
            }

            var dataShoot = await _context.DataShoot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataShoot == null)
            {
                return NotFound();
            }

            return View(dataShoot);
        }

        // GET: Admin/DataShoots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DataShoots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] DataShoot dataShoot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataShoot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataShoot);
        }

        // GET: Admin/DataShoots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DataShoot == null)
            {
                return NotFound();
            }

            var dataShoot = await _context.DataShoot.FindAsync(id);
            if (dataShoot == null)
            {
                return NotFound();
            }
            return View(dataShoot);
        }

        // POST: Admin/DataShoots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] DataShoot dataShoot)
        {
            if (id != dataShoot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataShoot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataShootExists(dataShoot.Id))
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
            return View(dataShoot);
        }

        // GET: Admin/DataShoots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DataShoot == null)
            {
                return NotFound();
            }

            var dataShoot = await _context.DataShoot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataShoot == null)
            {
                return NotFound();
            }

            return View(dataShoot);
        }

        // POST: Admin/DataShoots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataShoot == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DataShoot'  is null.");
            }
            var dataShoot = await _context.DataShoot.FindAsync(id);
            if (dataShoot != null)
            {
                _context.DataShoot.Remove(dataShoot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataShootExists(int id)
        {
          return _context.DataShoot.Any(e => e.Id == id);
        }
    }
}
