using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
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
        public async Task<IEnumerable<DetalleMovimientoModel>> GetByIdMovimiento(int idMovimiento)
        {
            var detallesMovimiento = await connection.QueryAsync<DetalleMovimientoModel>("Movimiento.GetDetalleMovimientoByIdMovimiento", new { IdMovimiento = idMovimiento }, transaction, null, CommandType.StoredProcedure);
            return detallesMovimiento;
        }
    }
}
