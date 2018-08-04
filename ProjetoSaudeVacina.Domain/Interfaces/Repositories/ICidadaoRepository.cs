using ProjetoSaudeVacina.Domain.Entities;
using System.Threading.Tasks;

namespace ProjetoSaudeVacina.Domain.Interfaces.Repositories
{
    public interface ICidadaoRepository : IGenericRepository<Cidadao>
    {
        Task<Cidadao> LoginAsync(string email, string senha);
    }
}
