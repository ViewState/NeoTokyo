using System;
using System.Collections.Generic;
using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Services
{
    public class DesignerService : ServiceBase<Designer, StaffWithDesignerViewModel>, IService<Designer, StaffWithDesignerViewModel>
    {
        public DesignerService(IRepository<Designer> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
        }

        public void Update(StaffWithDesignerViewModel data)
        {
            var target = Repository.GetById(data.ID);

            target.Active = data.IsDesigner;

            Repository.Update(target);
        }
    }
}
