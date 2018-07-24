using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.Domain.Services
{
    public class VacinaService : GenericService<Vacina>, IVacinaService
    {
        public VacinaService(IVacinaRepository repository) : base(repository)
        {
        }
    }
}
