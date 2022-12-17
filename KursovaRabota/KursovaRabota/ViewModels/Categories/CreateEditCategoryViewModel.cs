using Microsoft.Build.Framework;
namespace KursovaRabota.ViewModels.Categories
{
    public class CreateEditCategoryViewModel
    {

        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public List<CategoryDetailViewModel> CategoriesList { get; set; }
    }
}

