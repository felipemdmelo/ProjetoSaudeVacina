using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSaudeVacina.API.Models.PostoSaude.In
{
    public class PostoSaudePostInViewModel
    {
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [StringLength(30)]
        public string Latitude { get; set; }

        [StringLength(30)]
        public string Longitude { get; set; }
    }
}
