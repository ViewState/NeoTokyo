using System;
using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override String ProfileName => "ViewModelToDomainMappings";
        protected override void Configure()
        {
            CreateMap<CountryViewModel, Country>();
            CreateMap<ProcessViewModel, Process>();
            CreateMap<DepartmentViewModel, Department>();
            CreateMap<StaffWithDesignerViewModel, Staff>();
            CreateMap<StaffWithDesignerViewModel, Designer>().ForMember(vm => vm.StaffID, map => map.MapFrom(d => d.ID));
        }
    }
}