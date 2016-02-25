using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IUnitProcessStatuService
    {
        IEnumerable<UnitProcessStatu> GetAll();
        UnitProcessStatu GetById(Guid id);
        void CreateEntity(UnitProcessStatu data);
        void SaveEntity();
    }

    public class UnitProcessStatuService : IUnitProcessStatuService
    {
        private readonly IUnitProcessStatuRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitProcessStatuService(IUnitProcessStatuRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UnitProcessStatu> GetAll() => _repository.GetAll();

        public UnitProcessStatu GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(UnitProcessStatu data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
