using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository, IUsuarioRepository
    {
        public UsuarioRepository(IDbSession db) : base(db) { }
        public async Task<int> LoginDashboard(UsuarioModel usuario)
        {
            var id = await Connection.QueryFirstOrDefaultAsync<int>("Usuario.LoginDashboard", new { usuario.Correo, usuario.Password }, Transaction, commandType: CommandType.StoredProcedure);
            return id;
        }
        public async Task<int> Insert(UsuarioModel usuario)
        {
            var id = await Connection.ExecuteScalarAsync<int>("Usuario.InsertUsuario", new { usuario.Nombres, usuario.Apellidos, usuario.Correo, usuario.Celular, usuario.Documento, usuario.IdTipoDocumento, usuario.FechaNacimiento, usuario.Password, UsuarioCreacion = IdUsuario }, Transaction, commandType: CommandType.StoredProcedure);
            return id;
        }
    }
}
