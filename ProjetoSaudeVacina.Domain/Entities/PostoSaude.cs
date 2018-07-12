using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public class PostoSaude : AbstractEntity
    {
        [Required]
        public string Nome { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }

        public long? VacinaEstoqueId { get; set; }
        public virtual VacinaEstoque VacinaEstoque { get; set; }
    }
}
