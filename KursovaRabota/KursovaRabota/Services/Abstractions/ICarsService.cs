using KursovaRabota.ViewModels.Cars;
using KursovaRabota.ViewModels.CarSuppliers;
namespace KursovaRabota.Services.Abstractions
{
    public interface ICarsService
    {
        List<CarDetailsViewModel> GetAll();

        CarDetailsViewModel Get(int CarId);

        List<SelectableCarsViewModel> GetSelectableCars();

        void Add(CarCreateEditViewModel carCreateEditViewModel);

        void Update(CarCreateEditViewModel carCreateEditViewModel);

        void Delete(int CarId);
        
    }
}
