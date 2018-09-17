using ProjetoSaudeVacina.MVC.Models.AbstractEntity.Out;
using ProjetoSaudeVacina.MVC.Models.Endereco.Out;

namespace ProjetoSaudeVacina.MVC.Models.PostoSaude.Out
{
    public class PostoSaudeGetOutViewModel : AbstractEntityGetOutViewModel
    {
        public string Nome { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public EnderecoGetOutViewModel Endereco { get; set; }
    }
}
