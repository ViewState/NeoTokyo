using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
