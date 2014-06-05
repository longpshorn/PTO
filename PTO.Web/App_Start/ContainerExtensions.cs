using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using PTO.Core.Interfaces;
using PTO.Infrastructure;
using PTO.Web.Services;
using System.Configuration;
using System.Reflection;

namespace PTO.Web
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder RegisterWebDependencies(this ContainerBuilder builder)
        {
            string dataConnectionString = string.Concat(Assembly.GetExecutingAssembly().GetName().Name, ".ConnectionString");
            var connectionString = ConfigurationManager.ConnectionStrings[dataConnectionString].ConnectionString;

            return builder
                .RegisterApiControllers()
                .RegisterControllers()
                .RegisterDataContext(connectionString)
                .RegisterRenwebServices()
                .RegisterSession()
                .RegisterWebTypesModule();
        }

        public static ContainerBuilder RegisterApiControllers(this ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            return builder;
        }

        public static ContainerBuilder RegisterControllers(this ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            return builder;
        }

        public static ContainerBuilder RegisterDataContext(this ContainerBuilder builder, string connectionString)
        {
            builder
                .RegisterType<AppContext>()
                .WithParameter("nameOrConnectionString", connectionString)
                .InstancePerHttpRequest();
            return builder;
        }

        public static ContainerBuilder RegisterRenwebServices(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(IRenwebService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            return builder;
        }

        public static ContainerBuilder RegisterSession(this ContainerBuilder builder)
        {
            builder.RegisterType<DbSession<AppContext>>().As<ISession<AppContext>>().InstancePerHttpRequest();
            return builder;
        }

        public static ContainerBuilder RegisterWebTypesModule(this ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacWebTypesModule());
            return builder;
        }
    }
}