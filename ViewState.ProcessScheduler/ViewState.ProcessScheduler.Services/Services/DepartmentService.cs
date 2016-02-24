using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public class DepartmentService : ServiceBase<Department>, IService<Department>
    {
        public DepartmentService(IDepartmentRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork, repository)
        {
        }

        public void Update(Department data)
        {
            var target = Repository.GetById(data.ID);

            target.Name = data.Name;
            target.Active = data.Active;

            Repository.Update(target);
        }
    }
}
