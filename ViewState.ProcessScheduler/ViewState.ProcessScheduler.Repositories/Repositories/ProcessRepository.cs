using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class ProcessRepository : RepositoryBase<Process>, IProcessRepository
    {
        public ProcessRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IProcessRepository : IRepository<Process>
    {
    }
}
