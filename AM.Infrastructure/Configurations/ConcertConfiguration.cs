using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{

    internal class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
         //   builder.HasOne(r => r.Artiste)
         //.WithMany(p => p.Concerts)
         //.HasForeignKey(p => p.Artistefk);


         //   builder.HasOne(r => r.Festival)
         //.WithMany(p => p.Concerts)
         //.HasForeignKey(p => p.Festivalfk);
            builder.HasKey(p => new
            {
                p.ArtisteFk,
                p.FestivalFk,
                p.DateConcert
            });
        }
    }
}
