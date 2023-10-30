using DeLaSur.Backend.Domain.Services;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Services;
using DeLaSur.Backend.Infrastructure.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace DeLaSur.Backend.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDb, Db>();
            services.AddTransient<IScrapingService, ScrapingService>();
            return services;
        }
    }
}
