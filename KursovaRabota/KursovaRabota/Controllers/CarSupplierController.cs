using Microsoft.AspNetCore.Mvc;
using KursovaRabota.Services.Abstractions;
using KursovaRabota.ViewModels.CarSuppliers;

namespace KursovaRabota.Controllers
{
    public class CarSupplierController: Controller
    {
        private readonly ICarSupplierService carSupplierService;

        private readonly ICarsService carsService;

        public CarSupplierController(ICarSupplierService carSupplierService, ICarsService carService)
        {
            this.carSupplierService = carSupplierService;
            this.carsService = carsService;
        }

        public IActionResult ListAllCarSuppliers()
        {
            var carSupplierDetailList = carSupplierService.GetAll();
            return View(carSupplierDetailList);
        }

        public IActionResult CarSupplierDetails(int id)
        {
            var carSupplierDetail = carSupplierService.GetById(id);
            return View(carSupplierDetail);
        }

        public IActionResult EditCarSupplier(int? id)
        {
            if (!id.HasValue) return View(new CreateEditCarSupplierViewModel
            {
                Cars = carsService.GetSelectableCars()
            });

            CreateEditCarSupplierViewModel model = carSupplierService.GetCar(id.Value);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCarSupplier(CreateEditCarSupplierViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            if (viewModel.Id == 0) carSupplierService.Insert(viewModel);
            else carSupplierService.Update(viewModel);

            return RedirectToAction("ListAllCarSuppliers");
        }

        public IActionResult DeleteCarSupplier(int id)
        {
            carSupplierService.Delete(id);
            return RedirectToAction("ListAllCarSuppliers");
        }
    }
}
