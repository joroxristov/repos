using KursovaRabota.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using KursovaRabota.Models;


namespace KursovaRabota.Repositories.Implementations
{
    public class CarSupplierRepository: ICarSupplierRepository
    {
        private readonly KursovaRabotaDbContext kursovaRabotaDbContext;

        private readonly DbSet<CarSupplier> carSuppliersDbSet;

        public CarSupplierRepository(KursovaRabotaDbContext kursovaRabotaDbContext)
        {
            this.kursovaRabotaDbContext = kursovaRabotaDbContext;
            carSuppliersDbSet = kursovaRabotaDbContext.Set<CarSupplier>();
        }

        public CarSupplier GetById(int id)
        {
            return carSuppliersDbSet.Find(id);
        }

        public IQueryable<CarSupplier> GetAll()
        {
            return carSuppliersDbSet;
        }

        public void Insert(CarSupplier carSupplier)
        {
            carSuppliersDbSet.Add(carSupplier);
            kursovaRabotaDbContext.SaveChanges();
        }

        public void Update(CarSupplier carSupplier)
        {
            CarSupplier carSupplierInDB = GetCarSupplierWithCars(carSupplier.Id);

            if (carSupplierInDB != null) kursovaRabotaDbContext.Entry(carSupplierInDB).State = EntityState.Detached;

            kursovaRabotaDbContext.Entry(carSupplier).State = EntityState.Modified;

            kursovaRabotaDbContext.Car_CarSuppliers.RemoveRange(carSupplierInDB.Car_CarSuppliers);
            kursovaRabotaDbContext.SaveChanges();

            kursovaRabotaDbContext.Car_CarSuppliers.AddRange(carSupplier.Car_CarSuppliers);
            kursovaRabotaDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
           CarSupplier carSupplierInDB = carSuppliersDbSet
                .Include(carSupplier => carSupplier.Car_CarSuppliers)
                .FirstOrDefault(carSupplier => carSupplier.Id == id);

            kursovaRabotaDbContext.Car_CarSuppliers.RemoveRange(carSupplierInDB.Car_CarSuppliers);
            carSuppliersDbSet.Remove(carSupplierInDB);
            kursovaRabotaDbContext.SaveChanges();
        }

        private CarSupplier GetCarSupplierWithCars(int id)
        {
            return carSuppliersDbSet.Include(carSupplier => carSupplier.Car_CarSuppliers)
                .FirstOrDefault(carSupplier => carSupplier.Id == id);
        }
    }
}

