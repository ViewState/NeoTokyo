using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Repositories
{
    public class DesignerRepository : RepositoryBase<Designer>, IDesignerRepository
    {
        public DesignerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IDesignerRepository : IRepository<Designer>
    {
    }
}
