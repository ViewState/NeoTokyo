using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class CustomerOrderRepository : RepositoryBase<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICustomerOrderRepository : IRepository<CustomerOrder>
    {
    }
}
