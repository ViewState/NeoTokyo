using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
