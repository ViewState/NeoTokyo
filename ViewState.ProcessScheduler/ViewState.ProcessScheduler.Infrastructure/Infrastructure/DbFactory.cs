using ViewState.ProcessScheduler.Model;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ProcessSchedulerDbEntities _dbContext;
        public ProcessSchedulerDbEntities Init() => _dbContext ?? (_dbContext = new ProcessSchedulerDbEntities());
        protected override void DisposeCore() => _dbContext?.Dispose();
    }
}
