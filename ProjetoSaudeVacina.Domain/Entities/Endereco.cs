using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public class Endereco : AbstractEntity
    {
        [Required]
        [StringLength(maximumLength: 8, 
                      MinimumLength = 8, 
                      ErrorMessage = "CEP está com formato inválido")]
        public string CEP { get; set; }

        [Required]
        [MaxLength(50)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(10)]
        public string Numero { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [MaxLength(50)]
        public string PontoReferencia { get; set; }

        [Required]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }
    }
}
