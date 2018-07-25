using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Infra.Data.Context;

namespace ProjetoSaudeVacina.Infra.Data.Repositories
{
    public class VacinaRepository : GenericRepository<Vacina>, IVacinaRepository
    {
        public VacinaRepository(ProjetoSaudeVacinaContext db) : base(db)
        {
        }
    }
}
