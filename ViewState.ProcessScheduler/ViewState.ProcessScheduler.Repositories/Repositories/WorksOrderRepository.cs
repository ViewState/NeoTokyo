using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class WorksOrderRepository : RepositoryBase<WorksOrder>, IWorksOrderRepository
    {
        public WorksOrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IWorksOrderRepository : IRepository<WorksOrder>
    {
    }
}
