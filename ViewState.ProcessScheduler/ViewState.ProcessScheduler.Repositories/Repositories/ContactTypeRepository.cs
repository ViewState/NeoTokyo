using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class ContactTypeRepository : RepositoryBase<ContactType>, IContactTypeRepository
    {
        public ContactTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IContactTypeRepository : IRepository<ContactType>
    {
    }
}
