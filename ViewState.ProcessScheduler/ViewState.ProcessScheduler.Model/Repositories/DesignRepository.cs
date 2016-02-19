using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
