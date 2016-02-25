using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
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
