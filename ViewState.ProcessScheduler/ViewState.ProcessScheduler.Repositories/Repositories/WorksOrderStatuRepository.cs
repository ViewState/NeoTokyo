using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class WorksOrderStatuRepository : RepositoryBase<WorksOrderStatu>, IWorksOrderStatuRepository
    {
        public WorksOrderStatuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IWorksOrderStatuRepository : IRepository<WorksOrderStatu>
    {
    }
}
