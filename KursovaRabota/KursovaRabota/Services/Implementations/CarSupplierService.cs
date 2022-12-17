using KursovaRabota.Models;
using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.Services.Abstractions;
using KursovaRabota.ViewModels.CarSuppliers;
using KursovaRabota.ViewModels.Cars;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Services.Implementations
{
    public class CarSupplierService: ICarSupplierService
    {
        private readonly ICarSupplierRepository carSupplierRepository;

        private readonly ICarsRepository carsRepository;

        public CarSupplierService(ICarSupplierRepository carSupplierRepository, ICarsRepository carsRepository)
        {
            this.carSupplierRepository = carSupplierRepository;
            this.carsRepository = carsRepository;
        }

        public CarSupplierDetailViewModel GetById(int id)
        {
            var carSupplierInDB = carSupplierRepository.GetAll()

                .Include(carSupplier => carSupplier.Car_CarSuppliers) 
                .ThenInclude(car_CarSupplier => car_CarSupplier.Car)
                .FirstOrDefault(carSupplier => carSupplier.Id == id);

            if (carSupplierInDB == null) return null;



            return new CarSupplierDetailViewModel
            {
                Id = carSupplierInDB.Id,
                SupplierName = carSupplierInDB.SupplierName,
                Cars = carSupplierInDB.Car_CarSuppliers.Select(car_CarSupplier => new CarDetailsViewModel
                {
                    Id = car_CarSupplier.Car.Id,
                    CategoryId = car_CarSupplier.Car.CategoryId,
                    BrandId = car_CarSupplier.Car.BrandId,
                    ImageUrl = car_CarSupplier.Car.ImageUrl,
                    Name = car_CarSupplier.Car.Name,
                    Price = car_CarSupplier.Car.Price
                }).ToList()
            };
        }

        public List<CarSupplierDetailViewModel> GetAll()
        {
            return carSupplierRepository.GetAll()
                 .Include(carSupplier => carSupplier.Car_CarSuppliers)
                 .ThenInclude(car_CarSupplier => car_CarSupplier.Car)
                 .Select(carSupplier => new CarSupplierDetailViewModel
                 {
                     Id = carSupplier.Id,
                     SupplierName = carSupplier.SupplierName,
                     Cars = carSupplier.Car_CarSuppliers.Select(car_CarSupplier => new CarDetailsViewModel
                     {
                         Id = car_CarSupplier.Car.Id,
                         CategoryId = car_CarSupplier.Car.CategoryId,
                         BrandId = car_CarSupplier.Car.BrandId,
                         ImageUrl = car_CarSupplier.Car.ImageUrl,
                         Name = car_CarSupplier.Car.Name,
                         Price = car_CarSupplier.Car.Price
                     }).ToList()
                 }).ToList();
        }

        public CreateEditCarSupplierViewModel GetCar(int id)
        {
            var carSupplier = carSupplierRepository.GetAll()
                .Include(s => s.Car_CarSuppliers)
                .ThenInclude(car_carSupplier => car_carSupplier.Car)
                .FirstOrDefault(s => s.Id == id);

            var viewModel = new CreateEditCarSupplierViewModel
            {
                Id = carSupplier.Id,
                SupplierName = carSupplier.SupplierName,
            };

            List<Car> cars = carsRepository.GetAll().ToList();

            viewModel.Cars = cars.Select(car => new SelectableCarsViewModel
            {
                Id = car.Id,
                CategoryId = car.CategoryId,
                BrandId = car.BrandId,
                ImageUrl = car.ImageUrl,
                Name = car.Name,
                Price = car.Price,
                IsSelected = carSupplier.Car_CarSuppliers
                .Select(car_carSupplier => car_carSupplier.CarId)
                .Contains(car.Id)
            }).ToList();

            return viewModel;
        }

        public void Insert(CreateEditCarSupplierViewModel createEditCarSupplierViewModel)
        {
            var carSupplier = new CarSupplier()
            {
                Id = createEditCarSupplierViewModel.Id,
                SupplierName = createEditCarSupplierViewModel.SupplierName
            };

            carSupplierRepository.Insert(carSupplier); // insert

            var createdCarSupplier = carSupplierRepository.GetAll()
                .FirstOrDefault(carSupplier => carSupplier.SupplierName == createEditCarSupplierViewModel.SupplierName);

            createdCarSupplier.Car_CarSuppliers = createEditCarSupplierViewModel.Cars
                .Where(car => car.IsSelected)
                .Select(car => new Car_CarSupplier
                {
                    CarId = car.Id,
                    CarSupplierId = createdCarSupplier.Id
                }).ToList();

            carSupplierRepository.Update(createdCarSupplier);
        }

        public void Update(CreateEditCarSupplierViewModel createEditCarSupplierViewModel)
        {
            var carSupplier = new CarSupplier()
            {
                Id = createEditCarSupplierViewModel.Id,
                SupplierName = createEditCarSupplierViewModel.SupplierName,
                Car_CarSuppliers = createEditCarSupplierViewModel.Cars
                .Where(car => car.IsSelected)
                .Select(car => new Car_CarSupplier
                {
                    CarId = car.Id,
                    CarSupplierId = createEditCarSupplierViewModel.Id
                }).ToList()
            };
            carSupplierRepository.Update(carSupplier);
        }

        public void Delete(int id)
        {
            carSupplierRepository.Delete(id);
        }
    }
}

