using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace DeLaSur.Backend.Api.Installers.AutofacModules
{
    public class MediatRModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = MediatRConfigurationBuilder
                        .Create(AppDomain.CurrentDomain.Load("DeLaSur.Backend.Application"))
                        .WithAllOpenGenericHandlerTypesRegistered()
                        .WithRegistrationScope(RegistrationScope.Transient)
                        .Build();
            builder.RegisterMediatR(configuration);
        }
    }
}
