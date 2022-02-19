using Acessos.Empresa;
using Acessos.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Colore.Models
{
    public class Conexao : DbContext
    {
        public Conexao(DbContextOptions<Conexao> options) : base(options)
        {

        }
        public DbSet<Curriculo> curriculo { get; set; }
        public DbSet<Acessos> acesso { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Empresa> empresa { get; set; }
        public DbSet<Vaga> vaga { get; set; }
        public DbSet<Requisitos> requisitos { get; set; }
        public DbSet<Endereco> endereco { get; set; }
        public DbSet<Formacao> formacao { get; set; }
    }
}
