using Colore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acessos.Empresa
{
    [Table("Empresa")]
    public class Empresa 
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string titulo { get; set; }
        [Required]

        public string telefone { get; set; }
        [Required]
        public string cnpj { get; set; }        
        [Required]

        public Endereco endereco { get; set; }
        public ICollection<Vaga>? vagas { get; set; }
    }
}
