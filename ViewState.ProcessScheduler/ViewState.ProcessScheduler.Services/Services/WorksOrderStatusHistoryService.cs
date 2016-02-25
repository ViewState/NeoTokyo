using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IWorksOrderStatusHistoryService
    {
        IEnumerable<WorksOrderStatusHistory> GetAll();
        WorksOrderStatusHistory GetById(Guid id);
        void CreateEntity(WorksOrderStatusHistory data);
        void SaveEntity();
    }

    public class WorksOrderStatusHistoryService : IWorksOrderStatusHistoryService
    {
        private readonly IWorksOrderStatusHistoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public WorksOrderStatusHistoryService(IWorksOrderStatusHistoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<WorksOrderStatusHistory> GetAll() => _repository.GetAll();

        public WorksOrderStatusHistory GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(WorksOrderStatusHistory data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
