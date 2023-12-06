using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;
using DeLaSur.Backend.Domain.Utils;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class DetalleCompraRepository : IDetalleCompraRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public DetalleCompraRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task Save(List<DetalleCompraModel> detallesCompra, int idCompra, int usuarioCreacion)
        {
            var detalles = detallesCompra.Adapt<List<DetalleCompraUserDefinedTableType>>();
            await connection.ExecuteAsync("Compra.SaveDetalleCompra", new { Detalles = detalles.ToDataTable().AsTableValuedParameter(), IdCompra = idCompra, UsuarioCreacion = usuarioCreacion }, transaction, null, CommandType.StoredProcedure);
        }
    }
}
