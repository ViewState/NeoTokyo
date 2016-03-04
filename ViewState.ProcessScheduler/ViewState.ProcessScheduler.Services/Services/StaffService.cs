using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Services
{
    public class StaffService : ServiceBase<Staff,StaffWithDesignerViewModel>, IService<Staff,StaffWithDesignerViewModel>
    {
        public StaffService(IRepository<Staff> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
        }

        public void Update(StaffWithDesignerViewModel data)
        {
            Staff target = Repository.GetById(data.ID);

            target.FirstName = data.FirstName;
            target.Active = data.Active;
            target.MiddleName = data.MiddleName;
            target.LastName = data.LastName;

            Repository.Update(target);
        }
    }
}
