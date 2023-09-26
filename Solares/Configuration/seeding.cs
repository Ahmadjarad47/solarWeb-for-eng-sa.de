using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solares.Models;

namespace Solares.Configuration
{
    public class seeding : IEntityTypeConfiguration<Home>
    {
        public void Configure(EntityTypeBuilder<Home> builder)
        {
            builder.HasData(new Home
            {Title= "Beitrag zur Energiewende",
            Id=2123,
            Description= "Unser Ziel ist es, die Energie, die von der Natur zur Verfügung gestellt wird, effizient zu nutzen. So leisten wir einen wertvollen Beitrag in Zeiten der Energiewende und bieten unseren Kunden zukunftssichere Anlagen.",
                Image = "/img/133398153305477045.jpg"
            });

            
        }
    }
}
