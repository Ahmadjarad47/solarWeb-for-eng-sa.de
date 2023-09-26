using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Solares.Data;
using Solares.Models;

namespace Solares.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("OMAR$ADM�IN$Acc$sess")]
    public class HomesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
       

        public HomesController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Homes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Home.AsNoTracking().ToListAsync());
        }

        // GET: Admin/Homes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Home == null)
            {
                return NotFound();
            }

            var home = await _context.Home
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // GET: Admin/Homes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Image,TitleDe,DescriptionDe")] Home home)
        {
            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files;
                var ImageName = home.Image;
                if (file.Count() > 0)
                {
                    string webrootPath = webHostEnvironment.WebRootPath;
                    string ImagePath = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(file[0].FileName);
                    FileStream FileStram = new FileStream(Path.Combine(webrootPath, "img", ImagePath), FileMode.Create);
                    file[0].CopyTo(FileStram);
                    ImageName = @"/img/" + ImagePath;
                }
                home.Image = ImageName;

                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(home);
        }

        // GET: Admin/Homes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Home == null)
            {
                return NotFound();
            }

            var home = await _context.Home.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            return View(home);
        }

        // POST: Admin/Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Image,TitleDe,DescriptionDe")] Home home)
        {
            if (id != home.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var file = HttpContext.Request.Form.Files;
                    var ImageName = home.Image;
                    if (file.Count() > 0)
                    {
                        string webrootPath = webHostEnvironment.WebRootPath;
                        string removeOldroot = webHostEnvironment.WebRootPath;
                        var delete = removeOldroot + @"/img/" + home.Image;
                        System.IO.File.Delete(delete);
                        string ImagePath = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(file[0].FileName);
                        FileStream FileStram = new FileStream(Path.Combine(webrootPath, "img", ImagePath), FileMode.Create);
                        file[0].CopyTo(FileStram);
                        ImageName = @"/img/" + ImagePath;
                    }
                  

                    home.Image = ImageName;

                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.Id))
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
            return View(home);
        }

        // GET: Admin/Homes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Home == null)
            {
                return NotFound();
            }

            var home = await _context.Home
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Admin/Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Home == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Home'  is null.");
            }
            var home = await _context.Home.FindAsync(id);
            if (home != null)
            {
                string webrootPath = webHostEnvironment.WebRootPath;
                string removeOldroot = webHostEnvironment.WebRootPath;
                var delete = removeOldroot  + home.Image;
                System.IO.File.Delete(delete);
                _context.Home.Remove(home);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(int id)
        {
          return _context.Home.Any(e => e.Id == id);
        }
    }
}
