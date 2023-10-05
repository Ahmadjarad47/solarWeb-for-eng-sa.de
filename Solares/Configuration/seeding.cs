using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solares.Models;

namespace Solares.Configuration
{
    public class seeding : IEntityTypeConfiguration<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> builder)
        {
            builder.HasData(new Localization
            {
                active = true,
                Id = 1
            }) ;

            
        }
    }
}
