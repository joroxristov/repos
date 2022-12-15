using KursovaRabota.Models;
using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.Services.Abstractions;
using KursovaRabota.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public List<CategoryDetailViewModel> GetAll()
        {

            return this.categoriesRepository.GetAll()
                 .Select(category => new CategoryDetailViewModel
                 {
                     Id = category.Id,
                     CategoryName = category.CategoryName,
                     Cars = category.Cars.ToList()
                 }).ToList();
        }

        public CategoryDetailViewModel Get(int CategoryId)
        {
            var category = categoriesRepository.GetAll()
                .Include(b => b.Cars)
                .FirstOrDefault(b => b.Id == CategoryId);

            var viewModel = new CategoryDetailViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Cars = category.Cars.ToList<Car>()
            };


            return viewModel;
        }

        public void Add(CreateEditCategoryViewModel createEditCategoryViewModel)
        {
            var category = new Category()
            {
                Id = createEditCategoryViewModel.Id,
                CategoryName = createEditCategoryViewModel.CategoryName
            };

            categoriesRepository.Add(category);
        }

        public void Update(CreateEditCategoryViewModel createEditCategoryViewModel)
        {
            var category = new Category()
            {
                Id = createEditCategoryViewModel.Id,
                CategoryName = createEditCategoryViewModel.CategoryName
            };
            categoriesRepository.Update(category);
        }

        public void Delete(int id)
        {
            categoriesRepository.Delete(id);
        }
    }
}

