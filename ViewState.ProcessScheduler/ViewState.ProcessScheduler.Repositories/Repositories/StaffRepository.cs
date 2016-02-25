using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IStaffRepository : IRepository<Staff>
    {
    }
}
