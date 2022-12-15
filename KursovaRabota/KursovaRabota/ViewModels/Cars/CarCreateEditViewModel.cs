using KursovaRabota.ViewModels.Brands;
using Microsoft.Build.Framework;
using KursovaRabota.ViewModels.Categories;
using KursovaRabota.Models;

namespace KursovaRabota.ViewModels.Cars
{
    public class CarCreateEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<BrandDetailViewModel> BrandsList { get; set; }
        public List<CreateEditCategoryViewModel> CategoriesList { get; set; }
    }
}
