using Autofac;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
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
            builder.RegisterType<Db>().As<IDb>().InstancePerLifetimeScope();
            builder.RegisterType<DbSession>().As<IDbSession>()
                .OnActivating(e =>
                {
                    var obj = e.Instance;
                    obj.IdUsuario = 1;
                })
                .InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<MateriaPrimaRepository>().As<IMateriaPrimaRepository>().InstancePerDependency();
            builder.RegisterType<CategoriaMateriaPrimaRepository>().As<ICategoriaMateriaPrimaRepository>().InstancePerDependency();
        }
    }
}
