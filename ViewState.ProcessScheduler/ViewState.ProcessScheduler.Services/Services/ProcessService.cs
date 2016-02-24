﻿using System;
using System.Collections.Generic;
using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public class ProcessService : ServiceBase<Process>, IService<Process>
    {
        public ProcessService(IProcessRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
        }
        
        public void Update(Process process)
        {
            var targetProcess = Repository.GetById(process.ID);

            targetProcess.Active = process.Active;
            targetProcess.CompletedStatusText = process.CompletedStatusText;
            targetProcess.IsOverNightProcess = process.IsOverNightProcess;
            targetProcess.Name = process.Name;

            Repository.Update(targetProcess);
        }
    }
}
