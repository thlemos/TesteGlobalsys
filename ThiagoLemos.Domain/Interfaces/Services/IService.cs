using System.Collections;
using System.Collections.Generic;

namespace ThiagoLemos.Domain.Interfaces.Services
{
    public interface IService<T> where T:class
    {
        IList<T> ObterTodos();

        void Adicionar(T obj);

        void Atualizar(T obj);

        void Excluir(T obj);

        T ObterPorId(int id);

    }
}