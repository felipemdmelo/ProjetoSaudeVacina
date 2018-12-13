using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Exceptions;
using ProjetoSaudeVacina.Domain.Interfaces.Apps;
using ProjetoSaudeVacina.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSaudeVacina.Application.Apps
{
    public class CidadaoApp : ICidadaoApp
    {
        private readonly ICidadaoService _cidadaoService;

        public CidadaoApp(ICidadaoService cidadaoService)
        {
            // Services..
            _cidadaoService = cidadaoService;
        }

        public async Task AddAsync(Cidadao obj)
        {
            try
            {
                await _cidadaoService.AddAsync(obj);
            }
            catch (DomainException ex)
            {
                // Registrar no log como erro de regra de negócio..
                // Notificar interessados a respeito da violação da regra de negócio..
                throw;
            }
            catch (InfraDataException ex)
            {
                // Registrar no logo como erro de infra..
                // Notificar interessados a respeito da violação da regra de negócio..
                throw;
            }
        }
    }
}
