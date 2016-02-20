using System.Reflection;
using System.Web.Mvc;
using Antlr.Runtime;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;
using ViewState.ProcessScheduler.Services;
using ViewState.ProcessScheduler.Web.Mappings;

namespace ViewState.ProcessScheduler.Web
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof (AddressRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof (AddressService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.Register(c => new MapperConfiguration(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            }).CreateMapper()).As<IMapper>().SingleInstance();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}