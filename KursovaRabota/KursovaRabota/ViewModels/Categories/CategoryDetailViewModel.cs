using System.ComponentModel;
using KursovaRabota.Models;

namespace KursovaRabota.ViewModels.Categories
{
    public class CategoryDetailViewModel
    {
        [DisplayName("Category ID: ")]
        public int Id { get; set; }

        [DisplayName("Category name: ")]
        public string CategoryName { get; set; }

        public List<Car> Cars;
    }
}

