using Colore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acessos.Usuario
{  
        [Table("Usuario")]
        public class Usuario
        {
            [Key]
            public int id { get; set; }
            
            public Curriculo curriculo { get; set; }
            public ICollection<Vaga>? vagas { get; set; }     

        }
}
