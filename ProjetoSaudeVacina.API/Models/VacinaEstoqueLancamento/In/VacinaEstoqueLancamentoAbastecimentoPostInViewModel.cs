using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.In
{
    public class VacinaEstoqueLancamentoAbastecimentoPostInViewModel : VacinaEstoqueLancamentoPostInViewModel
    {
        [Required]
        [Range(1, 1000)]
        public int Quantidade { get; set; }
    }
}
