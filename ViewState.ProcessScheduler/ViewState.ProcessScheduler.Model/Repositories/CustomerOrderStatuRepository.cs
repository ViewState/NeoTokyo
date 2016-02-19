using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
