using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IUnitService
    {
        IEnumerable<Unit> GetAll();
        Unit GetById(Guid id);
        void CreateEntity(Unit data);
        void SaveEntity();
    }

    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitService(IUnitRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Unit> GetAll() => _repository.GetAll();

        public Unit GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(Unit data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
