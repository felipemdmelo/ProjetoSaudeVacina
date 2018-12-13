using ProjetoSaudeVacina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSaudeVacina.Domain.Interfaces.Apps
{
    public interface ICidadaoApp
    {
        Task AddAsync(Cidadao obj);
    }
}
