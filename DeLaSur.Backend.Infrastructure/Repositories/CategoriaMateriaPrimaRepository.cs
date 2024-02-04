using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class CategoriaMateriaPrimaRepository : Repository, ICategoriaMateriaPrimaRepository
    {
        public CategoriaMateriaPrimaRepository(IDbSession db) : base(db)
        {

        }
        public async Task<IEnumerable<CategoriaMateriaPrimaModel>> GetByIdTipoMateriaPrima(int idTipoMateriaPrima)
        {
            var categorias = await Connection.QueryAsync<CategoriaMateriaPrimaModel>("Material.GetCategoriaMateriaPrimaByIdTipoMateriaPrima", new { IdTipoMateriaPrima = idTipoMateriaPrima }, Transaction, null, CommandType.StoredProcedure);
            return categorias;
        }
    }
}
