using KursovaRabota.Models;
using KursovaRabota.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Repositories.Implementations
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly KursovaRabotaDbContext carsDbContext;
        private readonly DbSet<Category> dbSet;

        public CategoriesRepository(KursovaRabotaDbContext context)
        {
            this.carsDbContext = context;
            this.dbSet = this.carsDbContext.Set<Category>();
        }

        public Category Get(int CategoryId)
        {
            return this.dbSet.Find(CategoryId);
        }

        public IQueryable<Category> GetAll()
        {
            return this.dbSet;
        }

        public void Add(Category Category)
        {
            this.dbSet.Add(Category);
            this.carsDbContext.SaveChanges();
        }

        public void Delete(int CategoryId)
        {
            Category category = this.dbSet.Include(category => category.Cars)
                .FirstOrDefault(category => category.Id == CategoryId);

            if (category != null)
            {
                this.dbSet.Remove(category);
            }
            this.carsDbContext.SaveChanges();
        }

        public void Update(Category Category)
        {
            Category current = Get(Category.Id);

            if (current != null)
            {
                this.carsDbContext.Entry(current).State = EntityState.Detached;
            }

            this.carsDbContext.Entry(Category).State = EntityState.Modified;


            this.carsDbContext.SaveChanges();
        }
    }
}
