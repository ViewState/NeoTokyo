using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IDesignerService
    {
        IEnumerable<Designer> GetAll();
        Designer GetById(Guid id);
        void CreateEntity(Designer data);
        void SaveEntity();
    }

    public class DesignerService : IDesignerService
    {
        private readonly IDesignerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DesignerService(IDesignerRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Designer> GetAll() => _repository.GetAll();

        public Designer GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(Designer data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
