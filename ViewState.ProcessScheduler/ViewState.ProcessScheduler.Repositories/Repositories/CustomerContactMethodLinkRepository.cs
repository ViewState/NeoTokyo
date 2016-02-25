using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
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
