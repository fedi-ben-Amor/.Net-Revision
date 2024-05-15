
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {

        public DbSet<Artiste> Artistes { get; set; }
        public DbSet<Chanson> Chansons { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Concert> Concerts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
              Initial Catalog=FediBenAmorConcert;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        //public AMContext(DbContextOptions<AMContext> options) : base(options)
        //{

        //}

        public AMContext()
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public AMContext(DbContextOptions<AMContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concert>().HasOne(t => t.Festival).WithMany(t => t.Concerts).HasForeignKey(t => t.FestivalFk);
            modelBuilder.Entity<Concert>().HasOne(t => t.Artiste).WithMany(t => t.Concerts).HasForeignKey(t => t.ArtisteFk);
            modelBuilder.ApplyConfiguration(new ConcertConfiguration());

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .HaveMaxLength(50);
        }



    }
}
