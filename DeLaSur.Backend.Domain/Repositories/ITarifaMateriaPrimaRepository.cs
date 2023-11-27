using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface ITarifaMateriaPrimaRepository
    {
        Task<TarifaMateriaPrimaModel> GetById(int id);
        Task Save(List<TarifaMateriaPrimaModel> tarifasMateriaPrima, int idFuente);
    }
}
