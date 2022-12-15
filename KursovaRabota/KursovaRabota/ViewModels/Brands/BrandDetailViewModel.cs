using System.ComponentModel;
using KursovaRabota.Models;

namespace KursovaRabota.ViewModels.Brands
{
    public class BrandDetailViewModel
    {
        [DisplayName("Brand ID: ")]
        public int Id { get; set; }

        [DisplayName("Brand name: ")]
        public string BrandName { get; set; }

        public List<Car> Cars;
    }
}
