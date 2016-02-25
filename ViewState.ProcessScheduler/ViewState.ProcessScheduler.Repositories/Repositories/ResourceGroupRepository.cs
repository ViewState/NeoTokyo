using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class ResourceGroupRepository : RepositoryBase<ResourceGroup>, IResourceGroupRepository
    {
        public ResourceGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IResourceGroupRepository : IRepository<ResourceGroup>
    {
    }
}
