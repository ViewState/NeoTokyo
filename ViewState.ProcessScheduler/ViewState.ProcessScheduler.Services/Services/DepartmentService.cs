using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Services
{
    public class DepartmentService : ServiceBase<Department, DepartmentViewModel>, IService<Department, DepartmentViewModel>
    {
        public DepartmentService(IDepartmentRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
        }

        public void Update(DepartmentViewModel data)
        {
            var target = Repository.GetById(data.ID);

            target.Name = data.Name;
            target.Active = data.Active;

            Repository.Update(target);
        }
    }
}
