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
    public class OurServiceItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OurServiceItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/OurServiceItems
        public async Task<IActionResult> Index()
        {
              return View(await _context.OurServiceItem.ToListAsync());
        }

        // GET: Admin/OurServiceItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OurServiceItem == null)
            {
                return NotFound();
            }

            var ourServiceItem = await _context.OurServiceItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourServiceItem == null)
            {
                return NotFound();
            }

            return View(ourServiceItem);
        }

        // GET: Admin/OurServiceItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/OurServiceItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TitleDe,DescriptionDe,TypeIcon")] OurServiceItem ourServiceItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ourServiceItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourServiceItem);
        }

        // GET: Admin/OurServiceItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OurServiceItem == null)
            {
                return NotFound();
            }

            var ourServiceItem = await _context.OurServiceItem.FindAsync(id);
            if (ourServiceItem == null)
            {
                return NotFound();
            }
            return View(ourServiceItem);
        }

        // POST: Admin/OurServiceItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TitleDe,DescriptionDe,TypeIcon")] OurServiceItem ourServiceItem)
        {
            if (id != ourServiceItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ourServiceItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurServiceItemExists(ourServiceItem.Id))
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
            return View(ourServiceItem);
        }

        // GET: Admin/OurServiceItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OurServiceItem == null)
            {
                return NotFound();
            }

            var ourServiceItem = await _context.OurServiceItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourServiceItem == null)
            {
                return NotFound();
            }

            return View(ourServiceItem);
        }

        // POST: Admin/OurServiceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OurServiceItem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OurServiceItem'  is null.");
            }
            var ourServiceItem = await _context.OurServiceItem.FindAsync(id);
            if (ourServiceItem != null)
            {
                _context.OurServiceItem.Remove(ourServiceItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurServiceItemExists(int id)
        {
          return _context.OurServiceItem.Any(e => e.Id == id);
        }
    }
}
