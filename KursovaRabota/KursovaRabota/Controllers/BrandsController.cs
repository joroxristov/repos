using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.Repositories.Implementations;
using KursovaRabota.ViewModels.Brands;
using KursovaRabota.Services.Abstractions;

namespace KursovaRabota.Controllers
{
    public class BrandsController : Controller
    {
        private IBrandsService brandsService;

        public BrandsController(IBrandsService service)
        {
            this.brandsService = service;
        }

        public IActionResult ListAllBrands()
        {
            var list = this.brandsService.GetAll();
            return View(list);
        }
        public IActionResult Details(int BrandId)
        {
            var model = this.brandsService.Get(BrandId);
            return View(model);
        }

        public IActionResult Edit(int? BrandId)
        {
            if (!BrandId.HasValue)
            {
                Console.WriteLine(BrandId);
                return View(new CreateEditBrandViewModel());
            }
            else
            {
                var model = this.brandsService.Get(BrandId.Value);

                if (model == null)
                {
                    return RedirectToAction("ListAllBrands");
                }
                else
                {

                    return View(new CreateEditBrandViewModel()
                    {
                        Id = BrandId.Value,
                        BrandName = model.BrandName
                    });
                }
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(CreateEditBrandViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id == 0)
            {
                this.brandsService.Add(model);
            }
            else
            {
                this.brandsService.Update(model);
            }
            return RedirectToAction("ListAllBrands");
        }

        public IActionResult Delete(int BrandId)
        {
            this.brandsService.Delete(BrandId);
            return RedirectToAction("ListAllBrands");
        }
    }
}
