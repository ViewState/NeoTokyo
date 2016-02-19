using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
