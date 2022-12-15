using KursovaRabota.Models;
using KursovaRabota.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Repositories.Implementations
{
    public class BrandsRepository: IBrandsRepository
    {
        private readonly KursovaRabotaDbContext carsDbContext;
        private readonly DbSet<Brand> dbSet;

        public BrandsRepository(KursovaRabotaDbContext context)
        {
            this.carsDbContext = context;
            this.dbSet = this.carsDbContext.Set<Brand>();
        }

        public Brand Get(int BrandId)
        {
            return this.dbSet.Find(BrandId);
        }

        public IQueryable<Brand> GetAll()
        {
            return this.dbSet;
        }

        public void Add(Brand Brand)
        {
            this.dbSet.Add(Brand);
            this.carsDbContext.SaveChanges();
        }

        public void Delete(int BrandId)
        {
            Brand brand = this.dbSet.Include(brand => brand.Cars)
                .FirstOrDefault(brand => brand.Id == BrandId);

            if (brand != null)
            {
                this.dbSet.Remove(brand);
            }
            this.carsDbContext.SaveChanges();
        }

        public void Update(Brand Brand)
        {
            Brand current = Get(Brand.Id);

            if (current != null)
            {
                this.carsDbContext.Entry(current).State = EntityState.Detached;
            }

            this.carsDbContext.Entry(Brand).State = EntityState.Modified;


            this.carsDbContext.SaveChanges();
        }
    }
}

