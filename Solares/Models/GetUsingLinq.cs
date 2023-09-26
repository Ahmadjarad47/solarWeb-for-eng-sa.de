using Microsoft.EntityFrameworkCore;
using Solares.Data;
using System.Data.Common;

namespace Solares.Models
{
    public class GetUsingLinq
    {
        public static string connection= "Data Source=SQL5111.site4now.net;DataBase=db_a9f097_ahmad11;User Id=db_a9f097_ahmad11_admin;Password=Ahmad111";

        DbContextOptions<ApplicationDbContext> op = new DbContextOptionsBuilder<ApplicationDbContext>().UseLazyLoadingProxies().UseSqlServer(connection).Options;
        ApplicationDbContext context;
        public GetUsingLinq()
        {
            this.context = new ApplicationDbContext(op);
        }
        public  DbSet<Localization> Localizations()
        {
            return  context.Localization;
        }

    }
}
