﻿using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;

namespace ViewState.ProcessScheduler.Repositories
{
    public class UnitProcessStatuRepository : RepositoryBase<UnitProcessStatu>, IUnitProcessStatuRepository
    {
        public UnitProcessStatuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IUnitProcessStatuRepository : IRepository<UnitProcessStatu>
    {
    }
}
