using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class CustomerOrderStatusHistoryRepository : RepositoryBase<CustomerOrderStatusHistory>, ICustomerOrderStatusHistoryRepository
    {
        public CustomerOrderStatusHistoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICustomerOrderStatusHistoryRepository : IRepository<CustomerOrderStatusHistory>
    {
    }
}
