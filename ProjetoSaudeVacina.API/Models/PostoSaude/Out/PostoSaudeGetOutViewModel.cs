using ProjetoSaudeVacina.API.Models.AbstractEntity.Out;
using ProjetoSaudeVacina.API.Models.Endereco.Out;

namespace ProjetoSaudeVacina.API.Models.PostoSaude.Out
{
    public class PostoSaudeGetOutViewModel : AbstractEntityGetOutViewModel
    {
        public string Nome { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public EnderecoGetOutViewModel Endereco { get; set; }
    }
}
