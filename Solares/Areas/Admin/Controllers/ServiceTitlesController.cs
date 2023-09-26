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
    public class ServiceTitlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceTitlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ServiceTitles
        public async Task<IActionResult> Index()
        {
              return View(await _context.ServiceTitle.ToListAsync());
        }

        // GET: Admin/ServiceTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceTitle == null)
            {
                return NotFound();
            }

            var serviceTitle = await _context.ServiceTitle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceTitle == null)
            {
                return NotFound();
            }

            return View(serviceTitle);
        }

        // GET: Admin/ServiceTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ServiceTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TitleDe,DescriptionDe")] ServiceTitle serviceTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceTitle);
        }

        // GET: Admin/ServiceTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceTitle == null)
            {
                return NotFound();
            }

            var serviceTitle = await _context.ServiceTitle.FindAsync(id);
            if (serviceTitle == null)
            {
                return NotFound();
            }
            return View(serviceTitle);
        }

        // POST: Admin/ServiceTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TitleDe,DescriptionDe")] ServiceTitle serviceTitle)
        {
            if (id != serviceTitle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceTitleExists(serviceTitle.Id))
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
            return View(serviceTitle);
        }

        // GET: Admin/ServiceTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceTitle == null)
            {
                return NotFound();
            }

            var serviceTitle = await _context.ServiceTitle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceTitle == null)
            {
                return NotFound();
            }

            return View(serviceTitle);
        }

        // POST: Admin/ServiceTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceTitle == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServiceTitle'  is null.");
            }
            var serviceTitle = await _context.ServiceTitle.FindAsync(id);
            if (serviceTitle != null)
            {
                _context.ServiceTitle.Remove(serviceTitle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceTitleExists(int id)
        {
          return _context.ServiceTitle.Any(e => e.Id == id);
        }
    }
}
