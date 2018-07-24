using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSaudeVacina.Domain.Services
{
    public class GenericService<TEntity> : IDisposable, IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TEntity obj)
        {
            await _repository.AddAsync(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(long? id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(TEntity obj)
        {
            await _repository.RemoveAsync(obj);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await _repository.UpdateAsync(obj);
        }
    }
}
