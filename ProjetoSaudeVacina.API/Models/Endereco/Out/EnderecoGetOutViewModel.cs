using ProjetoSaudeVacina.API.Models.AbstractEntity.Out;

namespace ProjetoSaudeVacina.API.Models.Endereco.Out
{
    public class EnderecoGetOutViewModel : AbstractEntityGetOutViewModel
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
