using System;
using ViewState.ProcessScheduler.Model;

namespace ViewState.ProcessScheduler.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        ProcessSchedulerDbEntities Init();
    }
}
