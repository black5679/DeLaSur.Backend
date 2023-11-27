using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class DetalleMovimientoRepository : IDetalleMovimientoRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public DetalleMovimientoRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task Insert(List<DetalleMovimientoModel> detallesMovimiento)
        {
            var detalles = detallesMovimiento.Adapt<DetalleMovimientoUserDefinedTableType>();
            await connection.ExecuteAsync("Movimiento.InsertDetalleMovimiento", new { Detalles = detalles }, transaction, null, CommandType.StoredProcedure);
        }
    }
}
