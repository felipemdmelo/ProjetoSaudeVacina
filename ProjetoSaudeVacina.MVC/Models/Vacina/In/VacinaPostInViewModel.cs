using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.MVC.Models.Vacina.In
{
    public class VacinaPostInViewModel
    {
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}
