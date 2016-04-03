﻿using System.Collections.Generic;
namespace ThiagoLemos.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T:class 
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Save();
        void Delete(T entity);
    }
}