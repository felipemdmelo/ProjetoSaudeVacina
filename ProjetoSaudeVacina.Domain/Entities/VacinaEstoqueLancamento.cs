using ProjetoSaudeVacina.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public class VacinaEstoqueLancamento : AbstractEntity
    {
        [Required]
        public long PostoSaudeId { get; set; }
        public virtual PostoSaude PostoSaude { get; set; }

        [Required]
        public long VacinaId { get; set; }
        public virtual Vacina Vacina { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantidade { get; set; }

        [Required]
        public LancamentoEnum Tipo { get; set; }
    }
}
