using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.Models
{
    public class Car
    {
      

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }


        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Car_CarSupplier> Car_CarSuppliers { get; set; }
            = new List<Car_CarSupplier>();
    }
}
