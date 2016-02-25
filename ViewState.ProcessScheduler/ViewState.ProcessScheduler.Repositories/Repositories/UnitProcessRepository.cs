using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class UnitProcessRepository : RepositoryBase<UnitProcess>, IUnitProcessRepository
    {
        public UnitProcessRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IUnitProcessRepository : IRepository<UnitProcess>
    {
    }
}
