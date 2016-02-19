using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
{
    public class WorksOrderStatusHistoryRepository : RepositoryBase<WorksOrderStatusHistory>, IWorksOrderStatusHistoryRepository
    {
        public WorksOrderStatusHistoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IWorksOrderStatusHistoryRepository : IRepository<WorksOrderStatusHistory>
    {
    }
}
