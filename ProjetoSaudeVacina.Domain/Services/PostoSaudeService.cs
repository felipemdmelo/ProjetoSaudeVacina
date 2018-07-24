using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.Domain.Services
{
    public class PostoSaudeService : GenericService<PostoSaude>, IPostoSaudeService
    {
        public PostoSaudeService(IPostoSaudeRepository repository) : base(repository)
        {
        }
    }
}
