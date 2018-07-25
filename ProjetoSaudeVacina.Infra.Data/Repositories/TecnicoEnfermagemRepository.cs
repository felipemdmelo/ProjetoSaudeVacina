using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Infra.Data.Context;

namespace ProjetoSaudeVacina.Infra.Data.Repositories
{
    public class TecnicoEnfermagemRepository : GenericRepository<TecnicoEnfermagem>, ITecnicoEnfermagemRepository
    {
        public TecnicoEnfermagemRepository(ProjetoSaudeVacinaContext db) : base(db)
        {
        }
    }
}
