using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IUnitStatusHistoryService
    {
        IEnumerable<UnitStatusHistory> GetAll();
        UnitStatusHistory GetById(Guid id);
        void CreateEntity(UnitStatusHistory data);
        void SaveEntity();
    }

    public class UnitStatusHistoryService : IUnitStatusHistoryService
    {
        private readonly IUnitStatusHistoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitStatusHistoryService(IUnitStatusHistoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UnitStatusHistory> GetAll() => _repository.GetAll();

        public UnitStatusHistory GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(UnitStatusHistory data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
