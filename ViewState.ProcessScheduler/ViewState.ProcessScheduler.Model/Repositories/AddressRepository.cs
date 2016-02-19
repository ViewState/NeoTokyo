using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IAddressRepository : IRepository<Address>
    {
    }
}
