using DeLaSur.Backend.Domain.Models;
using System.Data;
using Dapper;
using DeLaSur.Backend.Domain.Repositories;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public UsuarioRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<IEnumerable<UsuarioModel>> Get()
        {
            var usuarios = await connection.QueryAsync<UsuarioModel>("Usuario.GetUsuario", null, transaction, null, CommandType.StoredProcedure);
            return usuarios;
        }
        public async Task<UsuarioModel> GetById(int id)
        {
            var usuario = await connection.QueryFirstOrDefaultAsync<UsuarioModel>("Usuario.GetByIdUsuario", new { Id = id }, transaction, null, CommandType.StoredProcedure);
            return usuario;
        }
        public async Task<int> Insert(UsuarioModel usuario)
        {
            var id = await connection.ExecuteScalarAsync<int>("Usuario.InsertUsuario", new { usuario.Nombres, usuario.Apellidos, usuario.Correo, usuario.Celular, usuario.FechaNacimiento, usuario.Documento, usuario.TipoDocumento, usuario.Password }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
        public async Task<int> Update(UsuarioModel usuario)
        {
            var id = await connection.ExecuteScalarAsync<int>("Usuario.Update", new { usuario.Nombres, usuario.Apellidos, usuario.Correo, usuario.Celular, usuario.FechaNacimiento, usuario.Documento, usuario.TipoDocumento }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
        public async Task<int> Delete(UsuarioModel usuario)
        {
            var id = await connection.ExecuteScalarAsync<int>("Usuario.Update", new { usuario.Id }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
