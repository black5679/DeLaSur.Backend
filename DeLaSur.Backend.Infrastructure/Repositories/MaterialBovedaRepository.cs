using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class MaterialBovedaRepository : Repository, IMaterialBovedaRepository
    {
        public MaterialBovedaRepository(IDbSession db) : base(db) { }
        public async Task<int> Save(List<MaterialBovedaModel> materialesBoveda, int usuarioCreacion)
        {
            var materiales = materialesBoveda.Adapt<List<MaterialBovedaUserDefinedTableType>>();
            var id = await Connection.ExecuteScalarAsync<int>("Boveda.SaveMaterialBoveda", new { Materiales = materiales.ToDataTable().AsTableValuedParameter(), UsuarioCreacion = usuarioCreacion }, Transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
