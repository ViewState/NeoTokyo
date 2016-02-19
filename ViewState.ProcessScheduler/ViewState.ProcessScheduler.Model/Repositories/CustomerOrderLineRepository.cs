using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
