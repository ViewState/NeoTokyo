﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public class CountryService : ServiceBase<Country>, IService<Country>
    {
        public CountryService(ICountryRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
        }
        
        public void Update(Country country)
        {
            var targetCountry = Repository.GetById(country.ID);

            targetCountry.Active = country.Active;
            targetCountry.Code = country.Code;
            targetCountry.Name = country.Name;

            Repository.Update(targetCountry);
        }
    }
}
