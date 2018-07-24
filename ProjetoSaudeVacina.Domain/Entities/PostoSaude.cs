﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

        public virtual List<VacinaEstoqueLancamento> VacinaEstoques { get; set; }
    }
}
