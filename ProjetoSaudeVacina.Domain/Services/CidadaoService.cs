using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.Domain.Services
{
    public class CidadaoService : GenericService<Cidadao>, ICidadaoService
    {
        public CidadaoService(ICidadaoRepository repository) : base(repository)
        {
        }
    }
}
