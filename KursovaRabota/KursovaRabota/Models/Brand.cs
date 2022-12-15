using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string BrandName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
            = new List<Car>();
    }
}
