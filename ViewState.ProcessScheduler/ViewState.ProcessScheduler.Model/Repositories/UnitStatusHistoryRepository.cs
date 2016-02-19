using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
