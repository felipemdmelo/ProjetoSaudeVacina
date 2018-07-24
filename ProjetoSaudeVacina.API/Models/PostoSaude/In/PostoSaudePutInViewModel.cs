using System.ComponentModel.DataAnnotations;

namespace ProjetoSaudeVacina.API.Models.PostoSaude.In
{
    public class PostoSaudePutInViewModel
    {
        [StringLength(30)]
        public string Latitude { get; set; }

        [StringLength(30)]
        public string Longitude { get; set; }
    }
}
