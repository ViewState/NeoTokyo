using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IStaffService
    {
        IEnumerable<Staff> GetAll();
        Staff GetById(Guid id);
        void CreateEntity(Staff data);
        void SaveEntity();
    }

    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StaffService(IStaffRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Staff> GetAll() => _repository.GetAll();

        public Staff GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(Staff data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
