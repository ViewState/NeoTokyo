using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
