using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IUnitStatuService
    {
        IEnumerable<UnitStatu> GetAll();
        UnitStatu GetById(Guid id);
        void CreateEntity(UnitStatu data);
        void SaveEntity();
    }

    public class UnitStatuService : IUnitStatuService
    {
        private readonly IUnitStatuRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitStatuService(IUnitStatuRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UnitStatu> GetAll() => _repository.GetAll();

        public UnitStatu GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(UnitStatu data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
