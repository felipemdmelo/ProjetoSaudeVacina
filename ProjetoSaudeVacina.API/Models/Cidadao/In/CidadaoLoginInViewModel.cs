using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.API.Models.Cidadao.In
{
    public class CidadaoLoginInViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Senha { get; set; }
    }
}
