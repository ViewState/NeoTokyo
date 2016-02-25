using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class UnitStatusHistoryRepository : RepositoryBase<UnitStatusHistory>, IUnitStatusHistoryRepository
    {
        public UnitStatusHistoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IUnitStatusHistoryRepository : IRepository<UnitStatusHistory>
    {
    }
}
