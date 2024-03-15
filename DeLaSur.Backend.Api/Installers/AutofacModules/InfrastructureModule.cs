using Autofac;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Services;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using DeLaSur.Backend.Infrastructure.Services;
using DeLaSur.Backend.Infrastructure.UoW;
using System.Data;
using System.Data.SqlClient;

namespace DeLaSur.Backend.Api.Installers.AutofacModules
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration configuration;
        public InfrastructureModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            string cs = configuration.GetConnectionString("Database") ?? throw new Exception();
            builder.Register(d => new SqlConnection(cs)).As<IDbConnection>().InstancePerLifetimeScope();
            // Unit of Work
            builder.RegisterType<Db>().As<IDb>().InstancePerLifetimeScope();
            builder.RegisterType<DbSession>().As<IDbSession>()
                .OnActivating(e =>
                {
                    var obj = e.Instance;
                    obj.IdUsuario = 1;
                })
                .InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            // Repositories
            builder.RegisterType<MateriaPrimaRepository>().As<IMateriaPrimaRepository>().InstancePerDependency();
            builder.RegisterType<CategoriaMateriaPrimaRepository>().As<ICategoriaMateriaPrimaRepository>().InstancePerDependency();
            builder.RegisterType<ColorRepository>().As<IColorRepository>().InstancePerDependency();
            builder.RegisterType<TarifaRepository>().As<ITarifaRepository>().InstancePerDependency();
            builder.RegisterType<BovedaRepository>().As<IBovedaRepository>().InstancePerDependency();
            builder.RegisterType<TipoBovedaRepository>().As<ITipoBovedaRepository>().InstancePerDependency();
            builder.RegisterType<TipoMovimientoRepository>().As<ITipoMovimientoRepository>().InstancePerDependency();
            builder.RegisterType<CompraRepository>().As<ICompraRepository>().InstancePerDependency();
            builder.RegisterType<DetalleCompraRepository>().As<IDetalleCompraRepository>().InstancePerDependency();
            builder.RegisterType<EntradaRepository>().As<IEntradaRepository>().InstancePerDependency();
            builder.RegisterType<DetalleEntradaRepository>().As<IDetalleEntradaRepository>().InstancePerDependency();
            builder.RegisterType<MaterialBovedaRepository>().As<IMaterialBovedaRepository>().InstancePerDependency();
            // Services
            builder.RegisterType<ScrapingService>().As<IScrapingService>().InstancePerDependency();
        }
    }
}
