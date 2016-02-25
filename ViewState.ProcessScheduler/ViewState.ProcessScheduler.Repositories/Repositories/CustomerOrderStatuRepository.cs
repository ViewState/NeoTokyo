using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class CustomerOrderStatuRepository : RepositoryBase<CustomerOrderStatu>, ICustomerOrderStatuRepository
    {
        public CustomerOrderStatuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICustomerOrderStatuRepository : IRepository<CustomerOrderStatu>
    {
    }
}
