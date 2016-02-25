using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class CustomerOrderLineStatuRepository : RepositoryBase<CustomerOrderLineStatu>, ICustomerOrderLineStatuRepository
    {
        public CustomerOrderLineStatuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICustomerOrderLineStatuRepository : IRepository<CustomerOrderLineStatu>
    {
    }
}
