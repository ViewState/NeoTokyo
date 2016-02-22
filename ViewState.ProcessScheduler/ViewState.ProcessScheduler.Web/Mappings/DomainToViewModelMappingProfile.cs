using System;
using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override String ProfileName => "DomainToViewModelMappings";

        protected override void Configure()
        {
            CreateMap<Country, CountryViewModel>();
            CreateMap<Process, ProcessViewModel>();
        }
    }
}