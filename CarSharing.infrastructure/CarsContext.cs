using Microsoft.EntityFrameworkCore;
using CarSharing.Domain.Cars;
using CarSharing.Domain.Orders;
using CarSharing.Domain.Users;

namespace CarSharing.infrastructure
{
    public class CarsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }

        public DbSet<CarCompany> CarCompanies { get; set; }
        public DbSet<CarBodyType> CarBodyTypes { get; set; }

        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarCompany>()
                .HasKey(k => new { k.CarId, k.CompanyId });

            modelBuilder.Entity<CarBodyType>()
                .HasKey(k => new { k.CarId, k.BodyTypeId });

        }
    }
}
