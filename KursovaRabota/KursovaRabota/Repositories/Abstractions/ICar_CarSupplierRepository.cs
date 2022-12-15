using KursovaRabota.Models;

namespace KursovaRabota.Repositories.Abstractions
{
    public interface ICar_CarSupplierRepository
    {
        Car_CarSupplier GetById(int id);

        List<Car_CarSupplier> GetAll();

        void Insert(Car_CarSupplier shoeSupplier);

        void Update(Car_CarSupplier shoeSupplier);

        void Delete(int id);
    }
}
