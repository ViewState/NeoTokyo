using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Services
{
    public class CountryService : ServiceBase<Country, CountryViewModel>, IService<Country, CountryViewModel>
    {
        public CountryService(ICountryRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
        }
        
        public void Update(CountryViewModel data)
        {
            var targetCountry = Repository.GetById(data.ID);

            targetCountry.Active = data.Active;
            targetCountry.Code = data.Code;
            targetCountry.Name = data.Name;

            Repository.Update(targetCountry);
        }
    }
}
