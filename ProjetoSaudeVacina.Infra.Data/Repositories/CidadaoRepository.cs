using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Infra.Data.Context;

namespace ProjetoSaudeVacina.Infra.Data.Repositories
{
    public class CidadaoRepository : GenericRepository<Cidadao>, ICidadaoRepository
    {
        public CidadaoRepository(ProjetoSaudeVacinaContext db) : base(db)
        { }

        public async Task<bool> ExistsByCPFOrEmail(string cpf, string email)
        {
            return await _db.Cidadao
                .Where(c => c.CPF == cpf || c.Email == email)
                .SingleOrDefaultAsync() != null;
        }

        public async Task<Cidadao> LoginAsync(string email, string senha)
        {
            return await _db.Set<Cidadao>()
                .Where(c => c.Email == email && c.Senha == senha && c.IsAtivo)
                .SingleOrDefaultAsync();
        }
    }
}
