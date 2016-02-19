using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
