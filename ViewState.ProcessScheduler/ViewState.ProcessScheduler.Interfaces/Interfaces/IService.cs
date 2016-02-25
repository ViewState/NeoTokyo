using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ViewState.ProcessScheduler.Interfaces
{
    public interface IService<TEntity, TViewModel>
    {
        IEnumerable<TViewModel> GetAll();
        IEnumerable<TViewModel> GetMany(Expression<Func<TEntity, Boolean>> where);
        TViewModel GetById(Guid? id);
        void Create(TViewModel data);
        void Update(TViewModel data);
        void Save();
    }
}
