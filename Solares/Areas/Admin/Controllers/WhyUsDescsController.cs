using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Solares.Data;

namespace Solares.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("OMAR$ADM�IN$Acc$sess")]
    public class WhyUsDescsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhyUsDescsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/WhyUsDescs1
        public async Task<IActionResult> Index()
        {
            return View(await _context.WhyUsDesc.ToListAsync());
        }

        // GET: Admin/WhyUsDescs1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WhyUsDesc == null)
            {
                return NotFound();
            }

            var whyUsDesc = await _context.WhyUsDesc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyUsDesc == null)
            {
                return NotFound();
            }

            return View(whyUsDesc);
        }

        // GET: Admin/WhyUsDescs1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/WhyUsDescs1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TitleDe,DescriptionDe,TypeIcon")] WhyUsDesc whyUsDesc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whyUsDesc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whyUsDesc);
        }

        // GET: Admin/WhyUsDescs1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WhyUsDesc == null)
            {
                return NotFound();
            }

            var whyUsDesc = await _context.WhyUsDesc.FindAsync(id);
            if (whyUsDesc == null)
            {
                return NotFound();
            }
            return View(whyUsDesc);
        }

        // POST: Admin/WhyUsDescs1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TitleDe,DescriptionDe,TypeIcon")] WhyUsDesc whyUsDesc)
        {
            if (id != whyUsDesc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whyUsDesc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhyUsDescExists(whyUsDesc.Id))
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
            return View(whyUsDesc);
        }

        // GET: Admin/WhyUsDescs1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WhyUsDesc == null)
            {
                return NotFound();
            }

            var whyUsDesc = await _context.WhyUsDesc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyUsDesc == null)
            {
                return NotFound();
            }

            return View(whyUsDesc);
        }

        // POST: Admin/WhyUsDescs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WhyUsDesc == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WhyUsDesc'  is null.");
            }
            var whyUsDesc = await _context.WhyUsDesc.FindAsync(id);
            if (whyUsDesc != null)
            {
                _context.WhyUsDesc.Remove(whyUsDesc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhyUsDescExists(int id)
        {
            return _context.WhyUsDesc.Any(e => e.Id == id);
        }
    }
}
