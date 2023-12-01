using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;
using DeLaSur.Backend.Domain.Utils;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class ProductoBovedaRepository : IProductoBovedaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public ProductoBovedaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<int> Save(List<ProductoBovedaModel> productosBoveda, int idBoveda, int usuarioCreacion)
        {
            var productos = productosBoveda.Adapt<List<ProductoBovedaUserDefinedTableType>>();
            var id = await connection.ExecuteScalarAsync<int>("Boveda.SaveProductoBoveda", new { Productos = productos.ToDataTable().AsTableValuedParameter(), IdBoveda = idBoveda, UsuarioCreacion = usuarioCreacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
