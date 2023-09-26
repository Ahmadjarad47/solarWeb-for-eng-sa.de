using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solares.Data;
using Solares.Models;
using System.Text;

namespace Solares.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("OMAR$ADM�IN$Acc$sess")]
    public class TablesController : Controller
    {
        private readonly ApplicationDbContext context;

        public TablesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {List<Email> result=await context.Emails.AsNoTracking().ToListAsync();
            return View(result);
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Emails == null)
            {
                return NotFound();
            }

            var serviceTitle = await context.Emails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceTitle == null)
            {
                return NotFound();
            }

            return View(serviceTitle);
        }

        [HttpPost]
        [ActionName("Delete")]  
        public async Task<IActionResult>Delete(int Id)
        {
            if (context.Emails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServiceTitle'  is null.");
            }
            var serviceTitle = await context.Emails.FindAsync(Id);
            if (serviceTitle != null)
            {
                context.Emails.Remove(serviceTitle);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }








        [HttpPost]
        [ActionName("Export")]
        public  FileResult Export()
        {var s= context.Emails.AsNoTracking().Count();
            List<object> customers = (from customer in this.context.Emails.Take(s)
                                      select new[] {
                                        customer.Name,
                                        customer.email,
                                        customer.subject,
                                        customer.body,
                                        customer.TimeSendEmail.ToString()
                                 }).ToList<object>();

            //Insert the Column Names.
            customers.Insert(0, new string[5] { "Name", "Email", "Subject", "Message","Time" });

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < customers.Count; i++)
            {
                string[] customer = (string[])customers[i];
                for (int j = 0; j < customer.Length; j++)
                {
                    //Append data with separator.
                    sb.Append(customer[j] + ',');
                }

                //Append new line character.
                sb.Append("\r\n");

            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }


    }
}
