using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
{
    public class StaffResourceGroupLinkRepository : RepositoryBase<StaffResourceGroupLink>, IStaffResourceGroupLinkRepository
    {
        public StaffResourceGroupLinkRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IStaffResourceGroupLinkRepository : IRepository<StaffResourceGroupLink>
    {
    }
}
