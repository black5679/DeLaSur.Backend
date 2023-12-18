using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class EspacioMaterialRepository : IEspacioMaterialRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public EspacioMaterialRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task Save(List<EspacioMaterialModel> espaciosMaterial, int idEspacio)
        {
            var espacios = espaciosMaterial.Adapt<EspacioMaterialUserDefinedTableType>();
            await connection.ExecuteAsync("Material.SaveEspacioMaterial", new { Espacios = espacios, IdEspacio = idEspacio }, transaction, null, CommandType.StoredProcedure);
        }
    }
}
