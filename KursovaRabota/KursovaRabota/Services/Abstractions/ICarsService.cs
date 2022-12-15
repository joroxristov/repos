using KursovaRabota.ViewModels.Cars;
using KursovaRabota.ViewModels.CarSuppliers;
namespace KursovaRabota.Services.Abstractions
{
    public interface ICarsService
    {
        List<CarDetailsViewModel> GetAll();

        CarDetailsViewModel Get(int CarId);

        List<SelectableCarsViewModel> GetSelectableCars();

        void Add(CreateEditCarSupplierViewModel createEditCarSupplierViewModel);

        void Update(CreateEditCarSupplierViewModel createEditCarSupplierViewModel);

        void Delete(int CarId);
        void Update(CarCreateEditViewModel model);
    }
}
