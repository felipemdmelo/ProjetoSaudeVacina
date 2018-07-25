using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.Domain.Entities
{
    public class PostoSaude : AbstractEntity
    {
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [StringLength(30)]
        public string Latitude { get; set; }

        [StringLength(30)]
        public string Longitude { get; set; }

        [Required]
        public long EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual List<VacinaEstoqueLancamento> VacinaEstoqueLancamentos { get; set; }
    }
}
