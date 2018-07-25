using Microsoft.EntityFrameworkCore;
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
            _db.Set<TEntity>().Add(obj);
            await _db.SaveChangesAsync();
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
