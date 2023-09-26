using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solares.Data;
using Solares.Models;
using Solares.Models.Views;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace Solares.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewHomes view = new ViewHomes()
            {
                localization = await context.Localization.AsNoTracking().FirstOrDefaultAsync(),
                Homes = await context.Home.AsNoTracking().ToListAsync()
                ,services=await context.Service.AsNoTracking().ToListAsync(),
                serviceTitles=await context.ServiceTitle.AsNoTracking().ToListAsync()
                ,whyUs=await context.WhyUs.AsNoTracking().ToListAsync()
                ,whyUsDes=await context.WhyUsDesc.AsNoTracking().ToListAsync(),
                OurServiceTitles=await context.OurServiceTitle.AsNoTracking().ToListAsync(),
                OurServiceItems=await context.OurServiceItem.AsNoTracking().ToListAsync()
              
            };
            return View(view);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SendEmail(string Name, string Email, string subject, string Body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new("info@eng-sa.de");
            mailMessage.To.Add("info@eng-sa.de");
            mailMessage.Subject = subject;
            mailMessage.Body = $"Name: {Name}\r\n Email:  {Email}\r\n  subject:   {subject}\r\n  Message:   {Body} ";

            Email e = new()
            {
                Name = Name,
                email = Email,
                body = Body,
                subject = subject,
                TimeSendEmail = DateTime.Now
            };
            await context.Emails.AddAsync(e);
            await context.SaveChangesAsync();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 8889;
            smtpClient.Host = "mail.eng-sa.de";
            smtpClient.Credentials = new NetworkCredential("info@eng-sa.de", "O@M2023-info");
            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = false;
           await smtpClient.SendMailAsync(mailMessage);
            return RedirectToAction(nameof(Index));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
