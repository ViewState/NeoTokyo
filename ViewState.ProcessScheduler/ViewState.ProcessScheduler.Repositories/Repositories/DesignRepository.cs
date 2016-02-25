using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class DesignRepository : RepositoryBase<Design>, IDesignRepository
    {
        public DesignRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IDesignRepository : IRepository<Design>
    {
    }
}
