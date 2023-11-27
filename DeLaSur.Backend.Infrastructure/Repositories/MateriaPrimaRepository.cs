using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class MateriaPrimaRepository : IMateriaPrimaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public MateriaPrimaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<MateriaPrimaModel> GetById(int id)
        {
            var materiaPrima = await connection.QueryFirstOrDefaultAsync<MateriaPrimaModel>("MateriaPrima.GetByIdMateriaPrima", new { Id = id }, transaction, null, CommandType.StoredProcedure);
            return materiaPrima;
        }
    }
}
