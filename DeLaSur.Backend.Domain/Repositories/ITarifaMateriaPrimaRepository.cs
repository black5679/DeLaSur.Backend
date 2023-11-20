using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface ITarifaMateriaPrimaRepository
    {
        Task<int> Save(List<TarifaMateriaPrimaModel> tarifaMateriaPrima);
    }
}
