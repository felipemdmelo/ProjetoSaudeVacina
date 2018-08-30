using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.API.Models.Pessoa.In
{
    public abstract class PessoaPostInViewModel
    {
        [Required]
        [StringLength(maximumLength: 11,
                      MinimumLength = 11,
                      ErrorMessage = "CPF está com formato inválido")]
        public string CPF { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string SobreNome { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "Email está com formato inválido")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Senha { get; set; }
    }
}
