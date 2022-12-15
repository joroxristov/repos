using KursovaRabota.Models;
using Microsoft.EntityFrameworkCore;



namespace KursovaRabota.Repositories
{
  
    public class KursovaRabotaDbContext: DbContext
    {
        public KursovaRabotaDbContext(DbContextOptions<KursovaRabotaDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarSupplier> CarSuppliers { get; set; }

        public DbSet<Car_CarSupplier> Car_CarSuppliers { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>()
                .HasOne(car => car.Car_CarSuppliers)
                .WithOne()
                .HasForeignKey(car_CarSupplier => car_CarSupplier.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Brand>()
                .HasMany(brand => brand.Cars)
                .WithOne(car => car.Brand)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(category => category.Cars)
                .WithOne(car => car.Category)
                .HasForeignKey(car => car.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarSupplier>()
                .HasMany(carSupplier => carSupplier.Car_CarSupplier)
                .WithOne()
                .HasForeignKey(car_CarSupplier => car_CarSupplier.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car_CarSupplier>()
                .HasOne(car_CarSupplier => car_CarSupplier.Car)
                .WithMany(car => car.Car_CarSupplier);

            modelBuilder.Entity<Car_CarSupplier>()
                .HasOne(car_CarSupplier => car_CarSupplier.CarSupplier)
                .WithMany(carSupplier => CarSupplier.Car_CarSupplier);

        }

    }
}
