using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class DetalleMovimientoRepository : Repository, IDetalleMovimientoRepository
    {
        public DetalleMovimientoRepository(IDbSession db) : base(db) { }
        public async Task<IEnumerable<DetalleMovimientoModel>> GetByIdMovimiento(int idMovimiento)
        {
            var detallesMovimiento = await Connection.QueryAsync<DetalleMovimientoModel>("Movimiento.GetDetalleMovimientoByIdMovimiento", new { IdMovimiento = idMovimiento }, Transaction, null, CommandType.StoredProcedure);
            return detallesMovimiento;
        }
    }
}
