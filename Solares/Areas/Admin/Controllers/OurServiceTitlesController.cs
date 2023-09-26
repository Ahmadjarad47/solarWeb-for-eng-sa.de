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
    public class OurServiceTitlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment WebHostEnvironment;

        public OurServiceTitlesController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            WebHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/OurServiceTitles
        public async Task<IActionResult> Index()
        {
              return View(await _context.OurServiceTitle.ToListAsync());
        }

        // GET: Admin/OurServiceTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OurServiceTitle == null)
            {
                return NotFound();
            }

            var ourServiceTitle = await _context.OurServiceTitle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourServiceTitle == null)
            {
                return NotFound();
            }

            return View(ourServiceTitle);
        }

        // GET: Admin/OurServiceTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/OurServiceTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TitleDe,DescriptionDe,Image")] OurServiceTitle ourServiceTitle)
        {
            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files;
                var ImageName = ourServiceTitle.Image;
                if (file.Count() > 0)
                {
                    string webrootPath = WebHostEnvironment.WebRootPath;
                    string ImagePath = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(file[0].FileName);
                    FileStream FileStram = new FileStream(Path.Combine(webrootPath, "img", ImagePath), FileMode.Create);
                    file[0].CopyTo(FileStram);
                    ImageName = @"/img/" + ImagePath;
                }
                ourServiceTitle.Image = ImageName;
                _context.Add(ourServiceTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourServiceTitle);
        }

        // GET: Admin/OurServiceTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OurServiceTitle == null)
            {
                return NotFound();
            }

            var ourServiceTitle = await _context.OurServiceTitle.FindAsync(id);
            if (ourServiceTitle == null)
            {
                return NotFound();
            }
            return View(ourServiceTitle);
        }

        // POST: Admin/OurServiceTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TitleDe,DescriptionDe,Image")] OurServiceTitle ourServiceTitle)
        {
            if (id != ourServiceTitle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var file = HttpContext.Request.Form.Files;
                    var ImageName = ourServiceTitle.Image;
                    if (file.Count() > 0)
                    {
                        string webrootPath = WebHostEnvironment.WebRootPath;
                        string removeOldroot = WebHostEnvironment.WebRootPath;
                        var delete = removeOldroot + @"/img/" + ourServiceTitle.Image;
                        System.IO.File.Delete(delete);
                        string ImagePath = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(file[0].FileName);
                        FileStream FileStram = new FileStream(Path.Combine(webrootPath, "img", ImagePath), FileMode.Create);
                        file[0].CopyTo(FileStram);
                        ImageName = @"/img/" + ImagePath;
                    }


                    ourServiceTitle.Image = ImageName;
                    _context.Update(ourServiceTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurServiceTitleExists(ourServiceTitle.Id))
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
            return View(ourServiceTitle);
        }

        // GET: Admin/OurServiceTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OurServiceTitle == null)
            {
                return NotFound();
            }

            var ourServiceTitle = await _context.OurServiceTitle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourServiceTitle == null)
            {
                return NotFound();
            }

            return View(ourServiceTitle);
        }

        // POST: Admin/OurServiceTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OurServiceTitle == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OurServiceTitle'  is null.");
            }
            var ourServiceTitle = await _context.OurServiceTitle.FindAsync(id);
            if (ourServiceTitle != null)
            {
                string webrootPath = WebHostEnvironment.WebRootPath;
                string removeOldroot = WebHostEnvironment.WebRootPath;
                var delete = removeOldroot + ourServiceTitle.Image;
                System.IO.File.Delete(delete);
                _context.OurServiceTitle.Remove(ourServiceTitle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurServiceTitleExists(int id)
        {
          return _context.OurServiceTitle.Any(e => e.Id == id);
        }
    }
}
