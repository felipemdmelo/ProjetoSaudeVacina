using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.Domain.Services
{
    public class TecnicoEnfermagemService : GenericService<TecnicoEnfermagem>, ITecnicoEnfermagemService
    {
        public TecnicoEnfermagemService(ITecnicoEnfermagemRepository repository) : base(repository)
        {
        }
    }
}
