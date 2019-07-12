using Cars.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cars.Data
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }

        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Model>()
                .HasOne(e => e.Make)
                .WithMany(e => e.Models)
                .HasForeignKey(e => e.MakeId);
        }
    }
}
