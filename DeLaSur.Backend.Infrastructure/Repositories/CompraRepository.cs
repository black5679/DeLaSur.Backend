using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class CompraRepository : Repository, ICompraRepository
    {
        public CompraRepository(IDbSession db) : base(db) { }
        public async Task<int> Insert(CompraModel compra)
        {
            var id = await Connection.ExecuteScalarAsync<int>("Compra.InsertCompra", new { compra.IdProveedor, UsuarioCreacion = IdUsuario }, Transaction, null, CommandType.StoredProcedure);
            return id;
        }
        public async Task<int> Update(CompraModel compra)
        {
            var id = await Connection.ExecuteScalarAsync<int>("Compra.UpdateCompra", new { compra.Id, compra.IdProveedor, UsuarioModificacion = IdUsuario }, Transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
