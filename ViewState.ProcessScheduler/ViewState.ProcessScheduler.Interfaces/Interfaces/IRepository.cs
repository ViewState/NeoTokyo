﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ViewState.ProcessScheduler.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, Boolean>> where);
        T GetById(Guid? id);
        T Get(Expression<Func<T, Boolean>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, Boolean>> where);
    }
}
