using KursovaRabota.Models;
using Microsoft.AspNetCore.Components;

namespace KursovaRabota.ViewModels.Cars
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

     

    }
}
