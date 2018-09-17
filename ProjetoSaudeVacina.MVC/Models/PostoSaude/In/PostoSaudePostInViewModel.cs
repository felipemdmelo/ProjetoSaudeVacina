using ProjetoSaudeVacina.MVC.Models.Endereco.In;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.MVC.Models.PostoSaude.In
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

        [Required]
        public EnderecoPostInViewModel Endereco { get; set; }
    }
}
