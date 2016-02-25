using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IWorksOrderStatuService
    {
        IEnumerable<WorksOrderStatu> GetAll();
        WorksOrderStatu GetById(Guid id);
        void CreateEntity(WorksOrderStatu data);
        void SaveEntity();
    }

    public class WorksOrderStatuService : IWorksOrderStatuService
    {
        private readonly IWorksOrderStatuRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public WorksOrderStatuService(IWorksOrderStatuRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<WorksOrderStatu> GetAll() => _repository.GetAll();

        public WorksOrderStatu GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(WorksOrderStatu data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
