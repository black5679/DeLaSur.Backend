using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public MaterialRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<MaterialModel> GetById(int id)
        {
            var material = await connection.QueryFirstOrDefaultAsync<MaterialModel>("Material.GetByIdMaterial", new { Id = id }, transaction, null, CommandType.StoredProcedure);
            return material;
        }
        public async Task<int> Insert(MaterialModel material)
        {
            var id = await connection.ExecuteScalarAsync<int>("Material.InsertMaterial", new { material.IdCategoriaMaterial, material.Nombre, material.Descripcion, material.UsuarioCreacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
