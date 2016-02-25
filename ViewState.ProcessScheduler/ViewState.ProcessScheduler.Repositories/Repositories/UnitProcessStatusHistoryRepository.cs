using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
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
