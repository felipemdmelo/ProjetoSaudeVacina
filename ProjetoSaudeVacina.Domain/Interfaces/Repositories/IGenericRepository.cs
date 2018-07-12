using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSaudeVacina.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        TEntity GetById(long id);
        List<TEntity> GetAll();        
    }
}
