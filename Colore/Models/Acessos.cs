using Acessos.Empresa;
using Acessos.Usuario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colore.Models
{
    [Table("Acessos")]
    public class Acessos
    {
        [Key]
        public int id { get; set; }        
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [StringLength(16, ErrorMessage = "Deve ter entre 5 e 50 caracteres", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Deve ser um e-mail válido")]
        public string email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(255, ErrorMessage = "Deve ter entre 5 e 255 caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string senha { get; set; }     
        public string? imagem { get; set; }
        public Usuario? usuario { get; set; }
        public Empresa? empresa { get; set; }
    }

 }
