using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
