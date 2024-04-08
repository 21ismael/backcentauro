using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }

        //Las migraciones generán las tabalas en base al DbSet
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Car)
            .WithMany()
            .HasForeignKey(r => r.CarId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Office)
                .WithMany()
                .HasForeignKey(r => r.OfficeId);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Office)     
                .WithMany(o => o.Cars)
                .HasForeignKey(c => c.OfficeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
