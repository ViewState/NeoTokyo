
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class AllocationRepository : RepositoryBase<Allocation>, IAllocationRepository
    {
        public AllocationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IAllocationRepository : IRepository<Allocation>
    {
    }
}
