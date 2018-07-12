using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public class VacinaEstoque : AbstractEntity
    {
        public virtual List<VacinaEstoqueItem> VacinaEstoqueItens { get; set; }
    }
}
