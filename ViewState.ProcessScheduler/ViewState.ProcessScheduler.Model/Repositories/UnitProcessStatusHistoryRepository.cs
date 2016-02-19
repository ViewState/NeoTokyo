using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
{
    public class UnitProcessStatusHistoryRepository : RepositoryBase<UnitProcessStatusHistory>, IUnitProcessStatusHistoryRepository
    {
        public UnitProcessStatusHistoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IUnitProcessStatusHistoryRepository : IRepository<UnitProcessStatusHistory>
    {
    }
}
