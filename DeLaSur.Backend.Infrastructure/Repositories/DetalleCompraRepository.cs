using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class DetalleCompraRepository : Repository, IDetalleCompraRepository
    {
        public DetalleCompraRepository(IDbSession db) : base(db) { }
        public async Task Save(List<DetalleCompraModel> detallesCompra, int idCompra)
        {
            var detalles = detallesCompra.Adapt<List<DetalleCompraUserDefinedTableType>>();
            await Connection.ExecuteAsync("Compra.SaveDetalleCompra", new { Detalles = detalles.ToDataTable().AsTableValuedParameter(), IdCompra = idCompra, UsuarioCreacion = IdUsuario }, Transaction, null, CommandType.StoredProcedure);
        }
    }
}
