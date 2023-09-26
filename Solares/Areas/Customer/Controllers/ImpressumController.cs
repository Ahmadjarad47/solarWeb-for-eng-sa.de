using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solares.Data;
using Solares.Models.Views;

namespace Solares.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ImpressumController : Controller
    {
        private readonly ApplicationDbContext context;

        public ImpressumController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Impressum()
        {
            ViewImpressum view = new ViewImpressum
            {
                localization=await context.Localization.FirstOrDefaultAsync(),
                GetIMPs=await context.IMP.AsNoTracking().ToListAsync()  
            };
            return View(view);
        }
    }
}
