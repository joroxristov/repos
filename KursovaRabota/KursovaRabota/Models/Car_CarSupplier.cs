using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.Models
{
    public class Car_CarSupplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CarId { get; set; }

        public int CarSupplierId { get; set; }

        public virtual Car Car { get; set; }

        public virtual CarSupplier CarSupplier { get; set; }
    }
}
