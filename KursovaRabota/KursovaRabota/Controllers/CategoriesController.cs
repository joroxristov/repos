
using KursovaRabota.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.ViewModels.Categories;
using KursovaRabota.Services.Implementations;

namespace KursovaRabota.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoriesService categoriesService;
        public CategoriesController(ICategoriesService service)
        {
            this.categoriesService = service;
        }

        public IActionResult ListAllCategories()
        {
            var list = this.categoriesService.GetAll();
            return View(list);
        }
        public IActionResult Details(int CategoryId)
        {
            var model = this.categoriesService.Get(CategoryId);
            return View(model);
        }

        public IActionResult Edit(int? CategoryId)
        {
            if (!CategoryId.HasValue)
            {
                Console.WriteLine(CategoryId);
                return View(new CreateEditCategoryViewModel());
            }
            else
            {
                var model = this.categoriesService.Get(CategoryId.Value);

                if (model == null)
                {
                    return RedirectToAction("ListAllCategories");
                }
                else
                {

                    return View(new CreateEditCategoryViewModel()
                    {
                        Id = CategoryId.Value,
                        CategoryName = model.CategoryName
                    });
                }
            }
        }
    }
}

        