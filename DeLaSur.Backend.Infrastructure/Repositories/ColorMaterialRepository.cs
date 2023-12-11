using Dapper;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Utils;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class ColorMaterialRepository : IColorMaterialRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public ColorMaterialRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task Save(List<int> colores, int idMaterial, int usuarioCreacion)
        {
            await connection.ExecuteAsync("Material.SaveColorMaterial", new { Detalles = colores.ToListString(), IdMaterial = idMaterial, UsuarioCreacion = usuarioCreacion }, transaction, null, CommandType.StoredProcedure);
        }
    }
}
