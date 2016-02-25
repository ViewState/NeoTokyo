using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IAllocationService
    {
        IEnumerable<Allocation> GetAll();
        Allocation GetById(Guid id);
        void CreateEntity(Allocation data);
        void SaveEntity();
    }

    public class AllocationService : IAllocationService
    {
        private readonly IAllocationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AllocationService(IAllocationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Allocation> GetAll() => _repository.GetAll();

        public Allocation GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(Allocation data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
