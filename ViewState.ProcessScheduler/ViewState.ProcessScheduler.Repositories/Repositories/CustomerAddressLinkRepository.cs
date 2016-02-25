using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class CustomerAddressLinkRepository : RepositoryBase<CustomerAddressLink>, ICustomerAddressLinkRepository
    {
        public CustomerAddressLinkRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICustomerAddressLinkRepository : IRepository<CustomerAddressLink>
    {
    }
}
