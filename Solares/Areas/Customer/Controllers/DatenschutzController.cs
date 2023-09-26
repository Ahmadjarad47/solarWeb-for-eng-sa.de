using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solares.Data;
using Solares.Models.Views;

namespace Solares.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class DatenschutzController : Controller
    {
        private readonly ApplicationDbContext context;

        public DatenschutzController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Datenschutz()
        {
            ViewData data = new ViewData
            {
                localization = await context.Localization.FirstOrDefaultAsync(),
                shoots = await context.DataShoot.AsNoTracking().ToListAsync()
            };
            return View(data);
        }
    }
}
