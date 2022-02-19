namespace Colore.Models
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }

        public string? Body { get; set; }

        public string? To { get; set; }

        public string? From { get; set; }

        public string? Subject { get; set; }

        public string? Content { get; set; }
    }
}
