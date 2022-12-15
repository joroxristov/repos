using KursovaRabota.ViewModels.CarSuppliers;
namespace KursovaRabota.Services.Abstractions
{
    public interface ICarSupplierService
    {
        CarSupplierDetailViewModel GetById(int id);

        List<CarSupplierDetailViewModel> GetAll();

        CreateEditCarSupplierViewModel GetCar(int id);

        void Insert(CreateEditCarSupplierViewModel createEditCarSupplierViewModel);

        void Update(CreateEditCarSupplierViewModel createEditCarSupplierViewModel);

        void Delete(int id);
    }
}
