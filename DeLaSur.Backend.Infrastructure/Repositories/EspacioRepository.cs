using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Utils;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class EspacioRepository : IEspacioRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public EspacioRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<int> Insert(EspacioModel espacio)
        {
            var id = await connection.ExecuteScalarAsync<int>("Material.InsertEspacio", new { espacio.IdForma, espacio.IdMaterial }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
        public async Task Save(List<EspacioModel> espacios, int idMaterial)
        {
            await connection.ExecuteAsync("Material.SaveEspacio", new { Espacios = espacios.ToDataTable().AsTableValuedParameter(), IdMaterial = idMaterial }, transaction, null, CommandType.StoredProcedure);
        }
    }
}
