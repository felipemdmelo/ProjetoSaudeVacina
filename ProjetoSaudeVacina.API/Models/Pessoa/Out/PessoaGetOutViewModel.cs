using ProjetoSaudeVacina.API.Models.AbstractEntity.Out;

namespace ProjetoSaudeVacina.API.Models.Pessoa.Out
{
    public abstract class PessoaGetOutViewModel : AbstractEntityGetOutViewModel
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
