using System.ComponentModel.DataAnnotations;

namespace ApiCadastroUsuario.DTO
{
    public class UsuarioCadastroDTO
    {
        
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }
        
        public string Email { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string NumeroContado { get; set; }

        public EnderecoCadastroDTO Endereco { get; set;}
    }
}
