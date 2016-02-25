using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IUnitProcessService
    {
        IEnumerable<UnitProcess> GetAll();
        UnitProcess GetById(Guid id);
        void CreateEntity(UnitProcess data);
        void SaveEntity();
    }

    public class UnitProcessService : IUnitProcessService
    {
        private readonly IUnitProcessRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitProcessService(IUnitProcessRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UnitProcess> GetAll() => _repository.GetAll();

        public UnitProcess GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(UnitProcess data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
