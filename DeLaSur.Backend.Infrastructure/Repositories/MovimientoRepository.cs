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
    public class MovimientoRepository : Repository, IMovimientoRepository
    {
        public MovimientoRepository(IDbSession db) : base(db) { }
        public async Task<MovimientoModel?> GetById(int id)
        {
            var movimiento = await Connection.QueryFirstOrDefaultAsync<MovimientoModel>("Movimiento.GetByIdMovimiento", new { Id = id }, Transaction, null, CommandType.StoredProcedure);
            return movimiento;
        }
        public async Task<int> Insert(MovimientoModel movimiento)
        {
            var detalles = movimiento.DetallesMovimiento.Adapt<List<DetalleMovimientoUserDefinedTableType>>();
            var id = await Connection.ExecuteScalarAsync<int>("Movimiento.InsertMovimiento", new { movimiento.IdTipoMovimiento, Detalles = detalles.ToDataTable().AsTableValuedParameter(), UsuarioCreacion = IdUsuario }, Transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
