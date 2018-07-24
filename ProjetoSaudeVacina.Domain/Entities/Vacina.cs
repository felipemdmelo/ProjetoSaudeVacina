using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public class Vacina : AbstractEntity
    {
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}
