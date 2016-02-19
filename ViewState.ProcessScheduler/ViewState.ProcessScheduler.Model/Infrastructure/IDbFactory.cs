
using System;

namespace ViewState.ProcessScheduler.Model.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ProcessSchedulerDbEntities Init();
    }
}
