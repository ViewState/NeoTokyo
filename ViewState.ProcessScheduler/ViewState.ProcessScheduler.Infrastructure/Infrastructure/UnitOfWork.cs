using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Model;

namespace ViewState.ProcessScheduler.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private ProcessSchedulerDbEntities _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public ProcessSchedulerDbEntities DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());
        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
