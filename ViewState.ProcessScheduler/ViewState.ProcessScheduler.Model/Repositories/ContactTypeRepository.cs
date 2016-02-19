using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;

namespace ViewState.ProcessScheduler.Model.Repositories
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
