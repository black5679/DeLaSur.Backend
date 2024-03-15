using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class BovedaRepository : Repository, IBovedaRepository
    {
        public BovedaRepository(IDbSession db) : base(db) { }
        public async Task<int> Insert(BovedaModel boveda)
        {
            var id = await Connection.ExecuteScalarAsync<int>("Boveda.InsertBoveda", new { boveda.IdTipoBoveda, boveda.Codigo, boveda.Descripcion, boveda.Ubicacion, UsuarioCreacion = IdUsuario }, Transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
