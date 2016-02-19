using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        Department GetById(Guid id);
        void CreateEntity(Department data);
        void SaveEntity();
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IDepartmentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Department> GetAll() => _repository.GetAll();

        public Department GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(Department data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
