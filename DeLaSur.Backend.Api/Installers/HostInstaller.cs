using Autofac.Extensions.DependencyInjection;
using Autofac;
using DeLaSur.Backend.Api.Installers.AutofacModules;

namespace DeLaSur.Backend.Api.Installers
{
    public static class HostInstaller 
    {
        public static IHostBuilder InstallAutofacModules(this IHostBuilder host, IConfiguration configuration)
        {
            host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            host.ConfigureContainer<ContainerBuilder>(containerBuilder => {
                containerBuilder.RegisterModule(new MediatRModule());
                containerBuilder.RegisterModule(new InfrastructureModule(configuration));
            });
            return host;
        }
    }
}
