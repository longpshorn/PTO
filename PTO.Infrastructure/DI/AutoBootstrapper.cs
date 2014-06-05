using Autofac;

namespace PTO.Infrastructure.DI
{
    public sealed class AutoBootstrapper
    {
        public static ContainerBuilder Bootstrap()
        {
            var builder = new ContainerBuilder()
                .RegisterLogManager()
                .RegisterRepositories()
                .RegisterEncryptor();
                //.RegisterValueInjector();
            return builder;
        }
    }
}
