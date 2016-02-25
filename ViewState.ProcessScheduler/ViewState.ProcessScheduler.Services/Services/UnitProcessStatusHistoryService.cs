using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IUnitProcessStatusHistoryService
    {
        IEnumerable<UnitProcessStatusHistory> GetAll();
        UnitProcessStatusHistory GetById(Guid id);
        void CreateEntity(UnitProcessStatusHistory data);
        void SaveEntity();
    }

    public class UnitProcessStatusHistoryService : IUnitProcessStatusHistoryService
    {
        private readonly IUnitProcessStatusHistoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitProcessStatusHistoryService(IUnitProcessStatusHistoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UnitProcessStatusHistory> GetAll() => _repository.GetAll();

        public UnitProcessStatusHistory GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(UnitProcessStatusHistory data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
