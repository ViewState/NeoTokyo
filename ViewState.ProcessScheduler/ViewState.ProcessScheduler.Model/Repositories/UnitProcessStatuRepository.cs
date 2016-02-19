using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
{
    public class UnitProcessStatuRepository : RepositoryBase<UnitProcessStatu>, IUnitProcessStatuRepository
    {
        public UnitProcessStatuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IUnitProcessStatuRepository : IRepository<UnitProcessStatu>
    {
    }
}
