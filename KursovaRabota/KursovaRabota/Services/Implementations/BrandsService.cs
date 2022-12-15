using KursovaRabota.Models;
using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.ViewModels.Brands;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Services.Implementations
{
    public class BrandsService
    {
        private readonly IBrandsRepository brandsRepository;

        public BrandsService(IBrandsRepository brandsRepository)
        {
            this.brandsRepository = brandsRepository;
        }

        public List<BrandDetailViewModel> GetAll()
        {

            return this.brandsRepository.GetAll()
                 .Select(brand => new BrandDetailViewModel
                 {
                     Id = brand.Id,
                     BrandName = brand.BrandName,
                     Cars = brand.Cars.ToList()
                 }).ToList();
        }

        public BrandDetailViewModel Get(int BrandId)
        {
            var brand = brandsRepository.GetAll()
                .Include(b => b.Cars)
                .FirstOrDefault(b => b.Id == BrandId);

            var viewModel = new BrandDetailViewModel
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                Cars = brand.Cars.ToList<Car>()
            };


            return viewModel;
        }

        public void Add(CreateEditBrandViewModel createEditBrandViewModel)
        {
            var brand = new Brand()
            {
                Id = createEditBrandViewModel.Id,
                BrandName = createEditBrandViewModel.BrandName
            };

            brandsRepository.Add(brand);
        }

        public void Update(CreateEditBrandViewModel createEditBrandViewModel)
        {
            var brand = new Brand()
            {
                Id = createEditBrandViewModel.Id,
                BrandName = createEditBrandViewModel.BrandName
            };
            brandsRepository.Update(brand);
        }

        public void Delete(int id)
        {
            brandsRepository.Delete(id);
        }
    }
}

