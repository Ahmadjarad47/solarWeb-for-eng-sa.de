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

namespace Solares.Areas.Admin
{
    [Area("Admin")]
    [Authorize("OMAR$ADM�IN$Acc$sess")]
    public class CookiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CookiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Cookies
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cookie.ToListAsync());
        }

        // GET: Admin/Cookies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cookie == null)
            {
                return NotFound();
            }

            var cookie = await _context.Cookie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookie == null)
            {
                return NotFound();
            }

            return View(cookie);
        }

        // GET: Admin/Cookies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Cookies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Cookie cookie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cookie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cookie);
        }

        // GET: Admin/Cookies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cookie == null)
            {
                return NotFound();
            }

            var cookie = await _context.Cookie.FindAsync(id);
            if (cookie == null)
            {
                return NotFound();
            }
            return View(cookie);
        }

        // POST: Admin/Cookies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Cookie cookie)
        {
            if (id != cookie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cookie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookieExists(cookie.Id))
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
            return View(cookie);
        }

        // GET: Admin/Cookies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cookie == null)
            {
                return NotFound();
            }

            var cookie = await _context.Cookie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookie == null)
            {
                return NotFound();
            }

            return View(cookie);
        }

        // POST: Admin/Cookies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cookie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cookie'  is null.");
            }
            var cookie = await _context.Cookie.FindAsync(id);
            if (cookie != null)
            {
                _context.Cookie.Remove(cookie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CookieExists(int id)
        {
          return _context.Cookie.Any(e => e.Id == id);
        }
    }
}
