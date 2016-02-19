using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
