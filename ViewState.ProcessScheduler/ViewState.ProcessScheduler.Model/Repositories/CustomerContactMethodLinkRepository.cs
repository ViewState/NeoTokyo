using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
{
    public class CustomerContactMethodLinkRepository : RepositoryBase<CustomerContactMethodLink>, ICustomerContactMethodLinkRepository
    {
        public CustomerContactMethodLinkRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICustomerContactMethodLinkRepository : IRepository<CustomerContactMethodLink>
    {
    }
}
