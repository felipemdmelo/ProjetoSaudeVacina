using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Infra.Data.Context;

namespace ProjetoSaudeVacina.Infra.Data.Repositories
{
    public class CidadaoRepository : GenericRepository<Cidadao>, ICidadaoRepository
    {
        public CidadaoRepository(ProjetoSaudeVacinaContext db) : base(db)
        {
        }
    }
}
