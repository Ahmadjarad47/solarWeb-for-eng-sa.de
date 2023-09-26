using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Solares.Data;
using Solares.Models;

namespace Solares.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("OMAR$ADM�IN$Acc$sess")]
    public class WhyUsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public WhyUsController(ApplicationDbContext context ,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/WhyUs
        public async Task<IActionResult> Index()
        {
              return View(await _context.WhyUs.ToListAsync());
        }

        // GET: Admin/WhyUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WhyUs == null)
            {
                return NotFound();
            }

            var whyUs = await _context.WhyUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyUs == null)
            {
                return NotFound();
            }

            return View(whyUs);
        }

        // GET: Admin/WhyUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/WhyUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TitleDe,DescriptionDe,Image")] WhyUs whyUs)
        {
            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files;
                var ImageName = whyUs.Image;
                if (file.Count() > 0)
                {
                    string webrootPath = webHostEnvironment.WebRootPath;
                    string ImagePath = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(file[0].FileName);
                    FileStream FileStram = new FileStream(Path.Combine(webrootPath, "img", ImagePath), FileMode.Create);
                    file[0].CopyTo(FileStram);
                    ImageName = @"/img/" + ImagePath;
                }
                whyUs.Image = ImageName;
                _context.Add(whyUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whyUs);
        }

        // GET: Admin/WhyUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WhyUs == null)
            {
                return NotFound();
            }

            var whyUs = await _context.WhyUs.FindAsync(id);
            if (whyUs == null)
            {
                return NotFound();
            }
            return View(whyUs);
        }

        // POST: Admin/WhyUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TitleDe,DescriptionDe,Image")] WhyUs whyUs)
        {
            if (id != whyUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var file = HttpContext.Request.Form.Files;
                    var ImageName = whyUs.Image;
                    if (file.Count() > 0)
                    {
                        string webrootPath = webHostEnvironment.WebRootPath;
                        string removeOldroot = webHostEnvironment.WebRootPath;
                        var delete = removeOldroot + @"/img/" + whyUs.Image;
                        System.IO.File.Delete(delete);
                        string ImagePath = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(file[0].FileName);
                        FileStream FileStram = new FileStream(Path.Combine(webrootPath, "img", ImagePath), FileMode.Create);
                        file[0].CopyTo(FileStram);
                        ImageName = @"/img/" + ImagePath;
                    }


                    whyUs.Image = ImageName;
                    _context.Update(whyUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhyUsExists(whyUs.Id))
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
            return View(whyUs);
        }

        // GET: Admin/WhyUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WhyUs == null)
            {
                return NotFound();
            }

            var whyUs = await _context.WhyUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyUs == null)
            {
                return NotFound();
            }

            return View(whyUs);
        }

        // POST: Admin/WhyUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WhyUs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WhyUs'  is null.");
            }
            var whyUs = await _context.WhyUs.FindAsync(id);
            if (whyUs != null)
            {
                string webrootPath = webHostEnvironment.WebRootPath;
                string removeOldroot = webHostEnvironment.WebRootPath;
                var delete = removeOldroot + whyUs.Image;
                System.IO.File.Delete(delete);

                _context.WhyUs.Remove(whyUs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhyUsExists(int id)
        {
          return _context.WhyUs.Any(e => e.Id == id);
        }
    }
}
