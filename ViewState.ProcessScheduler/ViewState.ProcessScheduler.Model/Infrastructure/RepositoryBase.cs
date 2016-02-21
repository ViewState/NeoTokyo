using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ViewState.ProcessScheduler.Model.Infrastructure
{
    public class RepositoryBase<T> where T : class
    {
        private ProcessSchedulerDbEntities _dbContext;
        private readonly IDbSet<T> _dbSet;
        protected IDbFactory DbFactory { get; private set; }
        protected ProcessSchedulerDbEntities DbContext => _dbContext ?? (_dbContext = DbFactory.Init());
        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }
        public virtual void Add(T entity) => _dbSet.Add(entity);
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity) => _dbSet.Remove(entity);
        public virtual void Delete(Expression<Func<T, Boolean>> where)
        {
            IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
            foreach (T obj in objects)
            {
                Delete(obj);
            }
        }
        public virtual T GetById(Guid? id) => _dbSet.Find(id);
        public virtual IEnumerable<T> GetAll() => _dbSet.ToList();
        public virtual IEnumerable<T> GetMany(Expression<Func<T, Boolean>> where) => _dbSet.Where(where).ToList(); 
        public T Get(Expression<Func<T, Boolean>> where) => _dbSet.Where(where).FirstOrDefault();
    }
}
