using System.ComponentModel;
using KursovaRabota.ViewModels.Cars;

namespace KursovaRabota.ViewModels.CarSuppliers
{
    public class CarSupplierDetailViewModel
    {
        [DisplayName("Car Supplier ID: ")]
        public int Id { get; set; }

        [DisplayName("Supplier: ")]
        public string SupplierName { get; set; }

        public List<CarDetailsViewModel> Cars;
    }
}
