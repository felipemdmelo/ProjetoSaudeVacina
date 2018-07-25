using ProjetoSaudeVacina.API.Models.AbstractEntity.Out;
using ProjetoSaudeVacina.API.Models.PostoSaude.Out;
using ProjetoSaudeVacina.API.Models.Vacina.Out;

namespace ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.Out
{
    public class VacinaEstoqueLancamentoGetOutViewModel : AbstractEntityGetOutViewModel
    {
        public PostoSaudeGetOutViewModel PostoSaude { get; set; }
        public virtual VacinaGetOutViewModel Vacina { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; }
    }
}
