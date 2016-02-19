using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
