using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
