using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IProcessService
    {
        IEnumerable<Process> GetAll();
        Process GetById(Guid? id);
        void CreateEntity(Process data);
        void SaveEntity();
        void Update(Process process);
    }

    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessService(IProcessRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Process> GetAll() => _repository.GetAll();

        public Process GetById(Guid? id) => _repository.GetById(id);

        public void CreateEntity(Process data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();

        public void Update(Process process)
        {
            var targetProcess = _repository.GetById(process.ID);

            targetProcess.Active = process.Active;
            targetProcess.CompletedStatusText = process.CompletedStatusText;
            targetProcess.IsOverNightProcess = process.IsOverNightProcess;
            targetProcess.Name = process.Name;

            _repository.Update(targetProcess);
        }
    }
}
