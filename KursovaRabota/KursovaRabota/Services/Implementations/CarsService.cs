using KursovaRabota.Models;
using KursovaRabota.Services.Abstractions;
using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.ViewModels.Cars;
using Microsoft.EntityFrameworkCore;



namespace KursovaRabota.Services.Implementations
{
    public class CarsService : ICarsService
    {
        private readonly ICarsRepository carsRepository;

        public CarsService(ICarsRepository repository)
        {
            this.carsRepository = repository;
        }

        public CarDetailsViewModel Get(int CarId)
        {
            var carInDatabase = carsRepository.GetAll()
                .Include(car => car.Brand)
                .Include(car => car.Category)
                .FirstOrDefault(car => car.Id == CarId);

            if (carInDatabase == null) return null;

            return new CarDetailsViewModel
            {
                Id = carInDatabase.Id,
                Name = carInDatabase.Name,
                Price = carInDatabase.Price,
                BrandId = carInDatabase.BrandId,
                CategoryId = carInDatabase.CategoryId,
                ImageUrl = carInDatabase.ImageUrl,
                Brand = carInDatabase.Brand,
                Category = carInDatabase.Category,
         
            };
        }

        public List<CarDetailsViewModel> GetAll()
        {
            return carsRepository.GetAll()
                
                .Include(car => car.Brand)
                .Select(car => new CarDetailsViewModel
                {
                    Id = car.Id,
                    Name = car.Name,
                    Price = car.Price,
                    BrandId = car.BrandId,
                    CategoryId = car.CategoryId,
                    ImageUrl = car.ImageUrl,
                    Brand = car.Brand,
                    Category = car.Category,
           
                }).ToList();
        }

        public List<SelectableCarsViewModel> GetSelectableCars()
        {
            return this.carsRepository.GetAll().Select(car => new SelectableCarsViewModel
            {
                Id = car.Id,
                Name = car.Name,
                Price = car.Price,
                ImageUrl = car.ImageUrl,
                CategoryId = car.CategoryId,
                BrandId = car.BrandId,
                IsSelected = false
            }).ToList();
        }

        public void Add(CarCreateEditViewModel model)
        {
            var car = new Car()
            {
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };
            this.carsRepository.Add(car);

        }

        public void Update(CarCreateEditViewModel model)
        {
            var car = new Car()
            {
                Id = model.Id,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };
            this.carsRepository.Update(car);
        }
        public void Delete(int CarId)
        {
            this.carsRepository.Delete(CarId);
        }
    }
}

