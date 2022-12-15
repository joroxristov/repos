using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.Models
{
    public class CarSupplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SupplierName { get; set; }

        public virtual ICollection<Car_CarSupplier> Car_CarSuppliers { get; set; }
            = new List<Car_CarSupplier>();
    }
}
