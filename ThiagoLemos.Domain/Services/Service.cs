using System.Collections.Generic;
using System.Linq;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Domain.Interfaces.Services;

namespace ThiagoLemos.Domain.Services
{
    public class Service<T> : IService<T> where T:class
    {
        protected IRepository<T> repo;


        public IList<T> ObterTodos()
        {
            return repo.GetAll().ToList();
        }

        public T ObterPorId(int id)
        {
            return repo.GetById(id);
        }

        public void Adicionar(T obj)
        {
            repo.Add(obj);
            repo.Save();
        }

        public void Atualizar(T obj)
        {
            repo.Update(obj);
            repo.Save();
        }

        public void Excluir(T obj)
        {
            repo.Delete(obj);
            repo.Save();
        }
    }
}