using Microsoft.EntityFrameworkCore;
using ProjetoSaudeVacina.Domain.Exceptions;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoSaudeVacina.Infra.Data.Repositories
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected ProjetoSaudeVacinaContext _db;

        public GenericRepository(ProjetoSaudeVacinaContext db)
        {
            _db = db;
        }

        public async Task AddAsync(TEntity obj)
        {
            try
            {
                _db.Set<TEntity>().Add(obj);
                await _db.SaveChangesAsync();
            }
            catch(Exception e)
            {
                var message = "Houve um erro para inserir o registro no banco. Tente novamente mais tarde, ou entre em contato com o suporte técnico!";
                throw new InfraDataException(message, e);
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(long? id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            _db.Set<TEntity>().Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}
