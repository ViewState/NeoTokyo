using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class DesignProcessRepository : RepositoryBase<DesignProcess>, IDesignProcessRepository
    {
        public DesignProcessRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IDesignProcessRepository : IRepository<DesignProcess>
    {
    }
}
