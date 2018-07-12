using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public class VacinaEstoqueItem : AbstractEntity
    {
        public long VacinaId { get; set; }
        public virtual Vacina Vacina { get; set; }
        public int Quantidade { get; set; }

        public long VacinaEstoqueId { get; set; }
        public virtual VacinaEstoque VacinaEstoque { get; set; }
    }
}
