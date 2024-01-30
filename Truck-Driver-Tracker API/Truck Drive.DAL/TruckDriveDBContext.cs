using Microsoft.EntityFrameworkCore;
using Truck_Drive.DAL.Entities;

namespace Truck_Drive.DAL
{
    public class TruckDriveDBContext : DbContext
    {
        public TruckDriveDBContext(DbContextOptions<TruckDriveDBContext> options)
            : base(options)
        {

        }

       /* public DbSet<Driver> Drivers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Truck> Trucks { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .Property(d => d.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Position>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Truck>()
                .Property(t => t.Id)
                .ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }
    }
}
