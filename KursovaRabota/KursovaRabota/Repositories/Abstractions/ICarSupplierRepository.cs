using KursovaRabota.Models;

namespace KursovaRabota.Repositories.Abstractions
{
    public interface ICarSupplierRepository
    {
        CarSupplier GetById(int id);

        IQueryable<CarSupplier> GetAll();

        void Insert(CarSupplier carSupplier);


        void Update(CarSupplier carSupplier);

        void Delete(int id);
    }
}
