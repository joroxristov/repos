
using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.Services.Abstractions;
using KursovaRabota.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;




namespace KursovaRabota.Controllers
{
    public class CarsController: Controller
    {
        private ICarsService carsService;
        private IBrandsService brandsService;
        private ICategoriesService categoriesService;

        public CarsController(ICarsService service, IBrandsService brandsService, ICategoriesService categoriesService)
        {
            this.carsService = service;
            this.brandsService = brandsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult AllCars()
        {
            var list = this.carsService.GetAll();
            return View(list);
        }
        public IActionResult Details(int CarId)
        {
            var model = this.carsService.Get(CarId);
            return View(model);
        }

        public IActionResult Edit(int? CarId)
        {

            var brands = this.brandsService.GetAll().ToList();
            var categories = this.categoriesService.GetAll().ToList();

            if (!CarId.HasValue)
            {
                return View(new CarCreateEditViewModel()
                {
                    BrandsList = brands,
                    CategoriesList = categories
                }); ;
            }
            else
            {
                var model = this.carsService.Get(CarId.Value);

                if (model == null)
                {
                    return RedirectToAction("AllCars");
                }
                else
                {

                    return View(new CarCreateEditViewModel()
                    {
                        Id = CarId.Value,
                        BrandId = model.BrandId,
                        Name = model.Name,
                        CategoryId = model.CategoryId,
                        ImageUrl = model.ImageUrl,
                        Price = model.Price,
                        BrandsList = brands,
                        CategoriesList = categories
                    });
                }
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(CarCreateEditViewModel model)
        {

            var brands = this.brandsService.GetAll().ToList();
            var categories = this.categoriesService.GetAll().ToList();

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Error");
                Console.WriteLine(string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
                return View(new CarCreateEditViewModel()
                {
                    Id = model.Id,
                    BrandId = model.BrandId,
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    BrandsList = brands,
                    CategoriesList = categories
                });
            }

            if (model.Id == 0)
            {
                this.carsService.Add(model);
            }
            else
            {
                this.carsService.Update(model);
            }
            return RedirectToAction("AllCars");
        }

        public IActionResult Delete(int CarId)
        {
            this.carsService.Delete(CarId);
            return RedirectToAction("AllCars");
        }
    }
}
