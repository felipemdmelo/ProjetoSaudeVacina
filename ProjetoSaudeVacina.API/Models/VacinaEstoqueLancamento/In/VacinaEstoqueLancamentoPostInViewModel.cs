using ProjetoSaudeVacina.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.In
{
    public class VacinaEstoqueLancamentoPostInViewModel
    {
        [Required]
        public long PostoSaudeId { get; set; }

        [Required]
        public long VacinaId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public LancamentoEnum Tipo { get; set; }
    }
}
