using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class CustomerOrderLineRepository : RepositoryBase<CustomerOrderLine>, ICustomerOrderLineRepository
    {
        public CustomerOrderLineRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICustomerOrderLineRepository : IRepository<CustomerOrderLine>
    {
    }
}
