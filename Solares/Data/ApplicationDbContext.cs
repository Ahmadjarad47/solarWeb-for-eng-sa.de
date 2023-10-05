using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solares.Models;
using System.Reflection;
using Solares.Data;

namespace Solares.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public virtual DbSet<Home> Home { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceTitle> ServiceTitle { get; set; }
        public virtual DbSet<Localization> Localization { get; set; }
        public virtual DbSet<WhyUs> WhyUs { get; set; }
        public virtual DbSet<WhyUsDesc> WhyUsDesc { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<OurServiceTitle> OurServiceTitle { get; set; }
        public virtual DbSet<OurServiceItem> OurServiceItem { get; set; }
        public virtual DbSet<Solares.Models.IMP> IMP { get; set; }
        public virtual DbSet<Solares.Models.DataShoot> DataShoot { get; set; }
        public virtual DbSet<Solares.Models.Cookie> Cookie { get; set; }
    }
}