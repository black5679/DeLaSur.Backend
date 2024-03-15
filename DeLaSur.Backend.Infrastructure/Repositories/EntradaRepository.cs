using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.Common;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class EntradaRepository : Repository, IEntradaRepository
    {
        public EntradaRepository(IDbSession db) : base(db) { }
        public async Task<int> Insert(EntradaModel entrada)
        {
            var detalles = entrada.Detalles.Adapt<List<DetalleEntradaUserDefinedTableType>>();
            var id = await Connection.ExecuteScalarAsync<int>("Entrada.InsertEntrada", new { entrada.IdProveedor, UsuarioCreacion = IdUsuario, Detalles = detalles.ToDataTable().AsTableValuedParameter() }, Transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
