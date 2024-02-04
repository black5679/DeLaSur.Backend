using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class SubCategoriaMateriaPrimaRepository : Repository, ISubCategoriaMateriaPrimaRepository
    {
        public SubCategoriaMateriaPrimaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<IEnumerable<SubCategoriaMateriaPrimaModel>> GetByIdCategoriaMateriaPrima(int idCategoriaMateriaPrima)
        {
            var subCategorias = await Connection.QueryAsync<SubCategoriaMateriaPrimaModel>("Material.GetSubCategoriaMateriaPrimaByIdCategoriaMateriaPrima", new { IdCategoriaMateriaPrima = idCategoriaMateriaPrima }, Transaction, null, CommandType.StoredProcedure);
            return subCategorias;
        }
    }
}
