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
    public class IMPsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMPsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/IMPs
        public async Task<IActionResult> Index()
        {
              return View(await _context.IMP.ToListAsync());
        }

        // GET: Admin/IMPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IMP == null)
            {
                return NotFound();
            }

            var iMP = await _context.IMP
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iMP == null)
            {
                return NotFound();
            }

            return View(iMP);
        }

        // GET: Admin/IMPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/IMPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] IMP iMP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iMP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iMP);
        }

        // GET: Admin/IMPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IMP == null)
            {
                return NotFound();
            }

            var iMP = await _context.IMP.FindAsync(id);
            if (iMP == null)
            {
                return NotFound();
            }
            return View(iMP);
        }

        // POST: Admin/IMPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] IMP iMP)
        {
            if (id != iMP.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iMP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IMPExists(iMP.Id))
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
            return View(iMP);
        }

        // GET: Admin/IMPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IMP == null)
            {
                return NotFound();
            }

            var iMP = await _context.IMP
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iMP == null)
            {
                return NotFound();
            }

            return View(iMP);
        }

        // POST: Admin/IMPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IMP == null)
            {
                return Problem("Entity set 'ApplicationDbContext.IMP'  is null.");
            }
            var iMP = await _context.IMP.FindAsync(id);
            if (iMP != null)
            {
                _context.IMP.Remove(iMP);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IMPExists(int id)
        {
          return _context.IMP.Any(e => e.Id == id);
        }
    }
}
