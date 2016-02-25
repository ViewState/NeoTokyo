using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class CustomerOrderLineStatusHistoryRepository : RepositoryBase<CustomerOrderLineStatusHistory>, ICustomerOrderLineStatusHistoryRepository
    {
        public CustomerOrderLineStatusHistoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICustomerOrderLineStatusHistoryRepository : IRepository<CustomerOrderLineStatusHistory>
    {
    }
}
