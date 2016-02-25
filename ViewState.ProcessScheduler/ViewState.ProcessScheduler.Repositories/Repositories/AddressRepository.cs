using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
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
