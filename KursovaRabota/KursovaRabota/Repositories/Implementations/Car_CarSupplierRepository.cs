using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.Models;
using Microsoft.EntityFrameworkCore;


namespace KursovaRabota.Repositories.Implementations
{
        public class Car_CarSupplierRepository : ICar_CarSupplierRepository
        {
            private readonly KursovaRabotaDbContext kursovaRabotaDbContext;

            private readonly DbSet<Car_CarSupplier> car_CarSupplierDbSet;

            public Car_CarSupplierRepository(KursovaRabotaDbContext kursovaRabotaDbContext)
            {
                this.kursovaRabotaDbContext = kursovaRabotaDbContext;
                car_CarSupplierDbSet = kursovaRabotaDbContext.Set<Car_CarSupplier>();
            }

            public Car_CarSupplier GetById(int id)
            {
           
                return kursovaRabotaDbContext.Car_CarSuppliers
                     .Include(car_CarSupplier => car_CarSupplier.CarSupplier)
                     .Include(car_CarSupplier => car_CarSupplier.Car)
                     .SingleOrDefault(car_CarSupplier => car_CarSupplier.Id == id);
            }

            public List<Car_CarSupplier> GetAll()
            {
                return kursovaRabotaDbContext.Car_CarSuppliers
                    .Include(car_CarSupplier => car_CarSupplier.CarSupplier)
                    .Include(car_CarSupplier => car_CarSupplier.Car)
                    .ToList();
            }

            public void Insert(Car_CarSupplier car_carSupplier)
            {
                car_CarSupplierDbSet.Add(car_carSupplier);
                kursovaRabotaDbContext.SaveChanges();
            }

            public void Update(Car_CarSupplier car_carSupplier)
            {
                Car_CarSupplier car_carSupplierInDB = GetById(car_carSupplier.Id);

                if (car_carSupplierInDB != null)
                {
                    kursovaRabotaDbContext.Entry(car_carSupplierInDB).State = EntityState.Detached;
                }
                kursovaRabotaDbContext.Entry(car_carSupplierInDB).State = EntityState.Modified;
                kursovaRabotaDbContext.SaveChanges();
            }

            public void Delete(int id)
            {
                car_CarSupplierDbSet.Remove(GetById(id));
                kursovaRabotaDbContext.SaveChanges();
            }
        }
    }

