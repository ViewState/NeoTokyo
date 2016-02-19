using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
