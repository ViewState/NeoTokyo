using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
