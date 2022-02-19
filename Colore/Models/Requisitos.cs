using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colore.Models
{
    [Table("Requisitos")]
    public class Requisitos
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string escolaridade { get; set; }
        
        [Required]
        public int experiencia { get; set; }
        [Required]
        public string idiomas { get; set; }

        [Required]
        public string area { get; set; }       

        
    }
}
