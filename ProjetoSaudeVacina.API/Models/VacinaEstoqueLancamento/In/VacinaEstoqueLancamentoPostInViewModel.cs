using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.In
{
    public abstract class VacinaEstoqueLancamentoPostInViewModel
    {
        [Required]
        public long PostoSaudeId { get; set; }

        [Required]
        public long VacinaId { get; set; }
    }
}
