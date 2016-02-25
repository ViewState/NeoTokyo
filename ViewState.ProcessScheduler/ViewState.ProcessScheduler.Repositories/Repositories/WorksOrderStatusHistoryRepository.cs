using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
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
