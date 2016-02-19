using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
