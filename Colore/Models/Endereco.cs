using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colore.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int cep { get; set; }

        [Required]
        public string rua { get; set; }

        [Required]
        public int numero { get; set; }

        [Required]
        public string Complemento { get; set; }

        [Required]
        public string bairro { get; set; }

        [Required]
        public string cidade { get; set; }

        [Required]
        public string uf { get; set; }

        [Required]
        public string pais { get; set; }
    }
}
