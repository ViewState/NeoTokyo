using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IWorksOrderService
    {
        IEnumerable<WorksOrder> GetAll();
        WorksOrder GetById(Guid id);
        void CreateEntity(WorksOrder data);
        void SaveEntity();
    }

    public class WorksOrderService : IWorksOrderService
    {
        private readonly IWorksOrderRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public WorksOrderService(IWorksOrderRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<WorksOrder> GetAll() => _repository.GetAll();

        public WorksOrder GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(WorksOrder data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
