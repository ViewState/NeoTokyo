using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class ContactMethodRepository : RepositoryBase<ContactMethod>, IContactMethodRepository
    {
        public ContactMethodRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IContactMethodRepository : IRepository<ContactMethod>
    {
    }
}
