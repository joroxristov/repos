using Microsoft.Build.Framework;
using KursovaRabota.ViewModels.Cars;

namespace KursovaRabota.ViewModels.CarSuppliers
{
    public class CreateEditCarSupplierViewModel
    {
        public int Id { get; set; }

        [Required]
        public string SupplierName { get; set; }

        public List<SelectableCarsViewModel> Cars { get; set; }
    }
}
