using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class MateriaPrimaRepository : Repository, IMateriaPrimaRepository
    {
        public MateriaPrimaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<int> Insert(MateriaPrimaModel materiaPrima)
        {
            var id = await Connection.ExecuteScalarAsync<int>("Material.InsertMateriaPrima", new { materiaPrima.IdSubCategoriaMateriaPrima, materiaPrima.Nombre, materiaPrima.Descripcion, UsuarioCreacion = IdUsuario }, Transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
