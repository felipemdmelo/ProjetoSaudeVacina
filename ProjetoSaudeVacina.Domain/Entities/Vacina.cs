using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public class Vacina : AbstractEntity
    {
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}
