using Autofac;
using DeLaSur.Backend.Domain.UoW;
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
            builder.Register(d => new SqlConnection(cs)).As<IDbConnection>();
            builder.RegisterType<Db>().As<IDb>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .OnActivating(e =>
                {
                    var obj = e.Instance;
                    obj.IdUsuario = 1;
                    //var user = e.Context.Resolve<IHttpContextAccessor>().HttpContext?.Request?.HttpContext?.User;
                    //if (user != null && user.Identity.IsAuthenticated)
                    //{
                    //    //obj.UserName = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value?.ToUpper();
                    //}
                })
                .InstancePerLifetimeScope();
        }
    }
}
