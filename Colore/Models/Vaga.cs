using Acessos.Empresa;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colore.Models
{
    [Table("Vaga")]
    public class Vaga
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string titulo { get; set; }
        [Required]
        public string cargo { get; set; }
        [Required]
        public double salario { get; set; }
        [Required]
        public string descricao { get; set; }
        [Required]
        public string beneficios { get; set; }       
        public DateTime dataFinalInscricao { get; set; }
        [Required]
        public Requisitos requisitos { get; set; }
        [Required]
        public Empresa empresa { get; set; }
    }
}
