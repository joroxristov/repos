using KursovaRabota.Models;
using KursovaRabota.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Repositories.Implementations
{
    public class CarsRepository: ICarsRepository
    {
        private readonly KursovaRabotaDbContext carsDbContext;

        private readonly DbSet<Car> dbSet;

        public CarsRepository(KursovaRabotaDbContext context)
        {
            this.carsDbContext = context;
            this.dbSet = this.carsDbContext.Set<Car>();
        }

        public void Add(Car car)
        {
            this.dbSet.Add(car);
            this.carsDbContext.SaveChanges();
        }

        public Car Get(int CarId)
        {
            Car car = this.dbSet
                .Include(car => car.Car_CarSuppliers)
                .Include(car => car.Brand)
                .Include(car => car.Category)
                .FirstOrDefault(car => car.Id == CarId);
            return car;
        }

        public IQueryable<Car> GetAll()
        {
            return dbSet;
        }


        public void Update(Car car)
        {
            Car current = Get(car.Id);

            if (current != null)
            {
                this.carsDbContext.Entry(current).State = EntityState.Detached;
            }

            this.carsDbContext.Entry(car).State = EntityState.Modified;

            this.carsDbContext.Car_CarSuppliers.RemoveRange((Car_CarSupplier)current.Car_CarSuppliers);

            this.carsDbContext.SaveChanges();

            this.carsDbContext.Car_CarSuppliers.AddRange((Car_CarSupplier)current.Car_CarSuppliers);

            this.carsDbContext.SaveChanges();
        }
        public void Delete(int CarId)
        {
            Car car = this.dbSet.Include(car => car.Car_CarSuppliers)
                 .FirstOrDefault(car => car.Id == CarId);

            if (car != null)
            {
                this.carsDbContext.Car_CarSuppliers.RemoveRange((Car_CarSupplier)car.Car_CarSuppliers);
                this.dbSet.Remove(car);
            }
            this.carsDbContext.SaveChanges();
        }

    }
}

