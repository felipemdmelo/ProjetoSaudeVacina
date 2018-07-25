using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.Domain.Services
{
    public class VacinaEstoqueLancamentoService : GenericService<VacinaEstoqueLancamento>, IVacinaEstoqueLancamentoService
    {
        public VacinaEstoqueLancamentoService(IVacinaEstoqueLancamentoRepository repository) : base(repository)
        {
        }
    }
}
