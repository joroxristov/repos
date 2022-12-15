using Microsoft.Build.Framework;
using KursovaRabota.ViewModels.Cars;
using KursovaRabota.Models;


namespace KursovaRabota.ViewModels.Brands
{
    public class CreateEditBrandViewModel
    {
        public int Id { get; set; }

        [Required]
        public string BrandName { get; set; }
    }
}
