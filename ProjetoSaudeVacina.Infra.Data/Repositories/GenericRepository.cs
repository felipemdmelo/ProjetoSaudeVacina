using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoSaudeVacina.Infra.Data.Repositories
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected ProjetoSaudeVacinaContext _db;

        public GenericRepository(ProjetoSaudeVacinaContext db)
        {
            _db = db;
        }

        public void Add(TEntity obj)
        {
            (obj as AbstractEntity).DataCadastro = DateTime.Now;

            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public List<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(long id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            _db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _db.Set<TEntity>().Update(obj);
            _db.SaveChanges();
        }
    }
}
