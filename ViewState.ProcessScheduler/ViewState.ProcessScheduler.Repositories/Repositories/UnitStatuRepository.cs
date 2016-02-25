using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class UnitStatuRepository : RepositoryBase<UnitStatu>, IUnitStatuRepository
    {
        public UnitStatuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IUnitStatuRepository : IRepository<UnitStatu>
    {
    }
}
