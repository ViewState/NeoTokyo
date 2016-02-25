using System;
using System.Collections.Generic;
using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Services
{
    public class ProcessService : ServiceBase<Process, ProcessViewModel>, IService<Process, ProcessViewModel>
    {
        public ProcessService(IProcessRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
        }
        
        public void Update(ProcessViewModel data)
        {
            var targetProcess = Repository.GetById(data.ID);

            targetProcess.Active = data.Active;
            targetProcess.CompletedStatusText = data.CompletedStatusText;
            targetProcess.IsOverNightProcess = data.IsOverNightProcess;
            targetProcess.Name = data.Name;

            Repository.Update(targetProcess);
        }
    }
}
