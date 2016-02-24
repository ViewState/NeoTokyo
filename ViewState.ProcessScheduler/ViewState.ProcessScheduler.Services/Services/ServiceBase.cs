using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Services
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

    public class ServiceBase<TEntity, TViewModel> 
    {
        public readonly IUnitOfWork UnitOfWork;
        public readonly IRepository<TEntity> Repository;
        public readonly IMapper Mapper;

        public ServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity> repository, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
            Mapper = mapper;
        }

        public IEnumerable<TViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TViewModel>>(Repository.GetAll());
        }

        public IEnumerable<TViewModel> GetMany(Expression<Func<TEntity, Boolean>> where)
        {
            return Mapper.Map<IEnumerable<TViewModel>>(Repository.GetMany(where));
        }

        public TViewModel GetById(Guid? id)
        {
            return Mapper.Map<TViewModel>(Repository.GetById(id));
        }

        public void Create(TViewModel data)
        {
            Repository.Add(Mapper.Map<TEntity>(data));
        }

        public void Save() => UnitOfWork.Commit();
    }
}
