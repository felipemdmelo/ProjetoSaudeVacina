using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.API.Models.Vacina.In
{
    public class VacinaPutInViewModel
    {
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}
