using KursovaRabota.Models;

namespace KursovaRabota.Repositories.Abstractions
{
    public interface ICategoriesRepository
    {
        void Add(Category Category);
        IQueryable<Category> GetAll();
        Category Get(int CategoryId);
        void Update(Category Category);
        void Delete(int CategoryId);
    }
}
