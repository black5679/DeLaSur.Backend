using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public MovimientoRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<MovimientoModel> GetById(int id)
        {
            var movimiento = await connection.QueryFirstOrDefaultAsync<MovimientoModel>("Movimiento.GetByIdMovimiento", new { Id = id }, transaction, null, CommandType.StoredProcedure);
            return movimiento;
        }
        public async Task<int> Insert(MovimientoModel movimiento)
        {
            var detalles = movimiento.DetallesMovimiento.Adapt<List<DetalleMovimientoUserDefinedTableType>>();
            var id = await connection.ExecuteScalarAsync<int>("Movimiento.InsertMovimiento", new { movimiento.IdTipoMovimiento, movimiento.IdInventario, movimiento.Inventario, Detalles = detalles.ToDataTable().AsTableValuedParameter(), movimiento.UsuarioCreacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
