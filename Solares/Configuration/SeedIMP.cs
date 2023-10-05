using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solares.Models;

namespace Solares.Configuration
{
    public class SeedIMP : IEntityTypeConfiguration<IMP>
    {
        public void Configure(EntityTypeBuilder<IMP> builder)
        {
            builder.HasData
             (new IMP
             {
                 Title = "Adresse",
                 Id = 1,
                 Description = "Ingenieurbüro Schmidt & Aljarad\r\nSoldier Str 32\r\nD-13359 Berlin",
             },new IMP
             {
                 Title= "Vertreten durch:",
                 Description= "Herr Marcus Schmidt\r\nHerr Omar Almatar Aljarad",
                 Id= 2,
             },new IMP
             {
                 Title= "Kontaktdaten",
                 Description= "Herr Marcus Schmidt\r\nE-Mail: m.schmidt@eng-sa.de\r\nHandynummer: +49 1577 3606583\r\n\r\nHerr Omar Almatar Aljarad\r\nE-Mail: o.aljarad@eng-sa.de\r\nHandynummer:  +49 177 1413741\r\n\r\nEmail für :\r\n1. allgemeine Anfragen: info@eng-sa.de\r\n2. Medienvertretende: presse@eng-sa.de\r\n3. Rechnung: invoice@eng-sa.de",
                 Id= 3,
             },new IMP
             {
                 Title= "Steuernummer\r\n",
                 Description= "23/513/00364",Id= 4,
             }
                
                
                );
        }
    }
}
