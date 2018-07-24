using ProjetoSaudeVacina.API.Models.PostoSaude.Out;
using ProjetoSaudeVacina.API.Models.Vacina.Out;
using ProjetoSaudeVacina.Domain.Entities.Enums;

namespace ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.Out
{
    public class VacinaEstoqueLancamentoGetOutViewModel
    {
        public long Id { get; set; }
        
        public PostoSaudeGetOutViewModel PostoSaude { get; set; }
        
        public virtual VacinaGetOutViewModel Vacina { get; set; }

        public int Quantidade { get; set; }
        public LancamentoEnum Tipo { get; set; }
    }
}
