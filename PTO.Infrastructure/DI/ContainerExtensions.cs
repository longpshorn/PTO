using Autofac;
using PTO.Core.Encryption;
using PTO.Core.Interfaces;
using PTO.Core.Logging;

namespace PTO.Infrastructure.DI
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder RegisterLogManager(this ContainerBuilder builder)
        {
            var logManager = new LogManagerFactory().Create();
            builder.RegisterInstance<ILogManager>(logManager).SingleInstance();
            return builder;
        }

        public static ContainerBuilder RegisterEncryptor(this ContainerBuilder builder)
        {
            builder.RegisterType<Encryptor>().As<IEncryptor>().InstancePerDependency();
            return builder;
        }

        public static ContainerBuilder RegisterRepositories(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(IUserRepository).Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            return builder;
        }

        /*
        public static ContainerBuilder RegisterValueInjector(this ContainerBuilder builder)
        {
            builder.RegisterType<ValueInjector>.As<IValueInjector>.InstancePerDependency();
            return builder;
        }
        */
    }
}
