using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class ColorRepository : Repository, IColorRepository
    {
        public ColorRepository(IDbSession db) : base(db)
        {

        }
        public async Task<int> Insert(ColorModel color)
        {
            var id = await Connection.ExecuteScalarAsync<int>("Material.InsertColor", new { color.Nombre, color.CodigoHex, UsuarioCreacion = IdUsuario }, Transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
