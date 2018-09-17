using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.MVC.Models.Endereco.In
{
    public class EnderecoPutInViewModel
    {
        public long Id { get; set; }

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
