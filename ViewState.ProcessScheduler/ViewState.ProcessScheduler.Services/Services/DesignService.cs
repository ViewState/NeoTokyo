using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IDesignService
    {
        IEnumerable<Design> GetAll();
        Design GetById(Guid id);
        void CreateEntity(Design data);
        void SaveEntity();
    }

    public class DesignService : IDesignService
    {
        private readonly IDesignRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DesignService(IDesignRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Design> GetAll() => _repository.GetAll();

        public Design GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(Design data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
