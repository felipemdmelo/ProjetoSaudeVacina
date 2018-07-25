using System;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public abstract class AbstractEntity
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataInativacao { get; set; }

        public AbstractEntity()
        {
            IsAtivo = true;
            DataCadastro = DateTime.Now;
        }

        public void Inativar()
        {
            IsAtivo = false;
            DataInativacao = DateTime.Now;
        }
    }
}
