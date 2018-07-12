using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public abstract class AbstractEntity
    {
        public long Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
