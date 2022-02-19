using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colore.Models
{
    [Table("Formacao")]
    public class Formacao
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string titulo { get; set; }
        [Required]
        public string nivel { get; set; }
        [Required]
        public string instituicao { get; set; }
        [Required]
        public DateTime inicio { get; set; }
        [Required]
        public DateTime fim { get; set; }
        [Required]
        public string? imagemDiploma { get; set; }
    }
}
