using ProjetoSaudeVacina.Domain.Entities;
using System.Threading.Tasks;

namespace ProjetoSaudeVacina.Domain.Interfaces.Repositories
{
    public interface ICidadaoRepository : IGenericRepository<Cidadao>
    {
        Task<bool> ExistsByCPFOrEmail(string cpf, string email);
        Task<Cidadao> LoginAsync(string email, string senha);
    }
}
