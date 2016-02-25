using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IUnitRepository : IRepository<Unit>
    {
    }
}
