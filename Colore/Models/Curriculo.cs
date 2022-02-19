using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colore.Models
{
    [Table("Curriculo")]
    public class Curriculo
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string sobrenome { get; set; }

        [Required]
        public string? nomeSocial { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string cpf { get; set; }

        [Required]
        public int rg { get; set; }

        [Required]
        public DateTime dataNasc { get; set; }
        [Required]
        public Requisitos requisitos { get; set; }
        [Required]
        public Endereco endereco { get; set; }

        [Required]
        List<Formacao>? formacao { get; set; }

    }
}
