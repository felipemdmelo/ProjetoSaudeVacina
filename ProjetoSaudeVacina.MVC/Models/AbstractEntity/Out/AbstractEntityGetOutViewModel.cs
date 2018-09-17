using System;

namespace ProjetoSaudeVacina.MVC.Models.AbstractEntity.Out
{
    public class AbstractEntityGetOutViewModel
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataInativacao { get; set; }
    }
}
