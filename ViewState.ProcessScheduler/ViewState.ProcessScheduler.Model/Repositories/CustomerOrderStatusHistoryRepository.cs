using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
