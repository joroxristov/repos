using KursovaRabota.ViewModels.Categories;


namespace KursovaRabota.Services.Abstractions
{
    public interface ICategoriesService
    {
        CategoryDetailViewModel Get(int id);

        List<CategoryDetailViewModel> GetAll();

        void Add(CreateEditCategoryViewModel createEditCategoryViewModel);

        void Update(CreateEditCategoryViewModel createEditCategoryViewModel);

        void Delete(int id);
    }
}
