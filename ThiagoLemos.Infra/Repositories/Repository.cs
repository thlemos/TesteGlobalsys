using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Infra.Contextos;

namespace ThiagoLemos.Infra
{
    public class Repository<T>: IRepository<T> where T:class
    {
        protected Contexto db;
        
        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().AsNoTracking();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }
        

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
        }
    }
}
