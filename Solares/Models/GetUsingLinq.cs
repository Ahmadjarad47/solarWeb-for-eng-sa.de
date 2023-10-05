using Microsoft.EntityFrameworkCore;
using Solares.Data;
using System.Data.Common;

namespace Solares.Models
{
    public class GetUsingLinq
    {
        public static string connection= "Server=(localdb)\\MSSQLLocalDB;Database=aspnet-Solares-af4442b3-e7a4-4b8d-976e-7412745a59cd;Trusted_Connection=True;MultipleActiveResultSets=true";

        DbContextOptions<ApplicationDbContext> op = new DbContextOptionsBuilder<ApplicationDbContext>().UseLazyLoadingProxies().UseSqlServer(connection).Options;
        ApplicationDbContext context;
        public GetUsingLinq()
        {
            this.context = new ApplicationDbContext(op);
        }
        public  DbSet<Cookie> cookie()
        {
            return  context.Cookie;
        }

    }
}
