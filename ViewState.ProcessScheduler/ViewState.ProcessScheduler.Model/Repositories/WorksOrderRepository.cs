using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
