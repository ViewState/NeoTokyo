using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IDesignProcessService
    {
        IEnumerable<DesignProcess> GetAll();
        DesignProcess GetById(Guid id);
        void CreateEntity(DesignProcess data);
        void SaveEntity();
    }

    public class DesignProcessService : IDesignProcessService
    {
        private readonly IDesignProcessRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DesignProcessService(IDesignProcessRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DesignProcess> GetAll() => _repository.GetAll();

        public DesignProcess GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(DesignProcess data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
