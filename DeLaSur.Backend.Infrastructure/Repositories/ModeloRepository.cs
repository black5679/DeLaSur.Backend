using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public ModeloRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task Save(List<string> modelos, int idMaterial, int usuarioCreacion)
        {
            await connection.ExecuteAsync("Material.SaveModelo", new { Modelos = modelos.ToListString(), IdMaterial = idMaterial, UsuarioCreacion = usuarioCreacion }, transaction, null, CommandType.StoredProcedure);
        }
        public async Task<int> Insert(ModeloModel modelo)
        {
            var id = await connection.ExecuteScalarAsync<int>("Material.InsertModelo", new { modelo.IdMaterial, modelo.Extension, modelo.UsuarioCreacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
