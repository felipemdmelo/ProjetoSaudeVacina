using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public abstract class Pessoa : AbstractEntity
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
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Senha { get; set; }

        //public virtual List<Endereco> Endereco { get; set; }
    }
}
