using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSaudeVacina.Domain.Services
{
    public class VacinaEstoqueLancamentoService : GenericService<VacinaEstoqueLancamento>, IVacinaEstoqueLancamentoService
    {
        public VacinaEstoqueLancamentoService(IVacinaEstoqueLancamentoRepository repository) : base(repository)
        {
        }
    }
}
