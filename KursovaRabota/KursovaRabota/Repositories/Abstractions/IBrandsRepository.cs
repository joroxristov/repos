using KursovaRabota.Models;

namespace KursovaRabota.Repositories.Abstractions
{
    public interface IBrandsRepository
    {
        void Add(Brand Brand);
        IQueryable<Brand> GetAll();
        Brand Get(int BrandId);
        void Update(Brand brand);
        void Delete(int BrandId);
    }
}
