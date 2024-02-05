using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface ITarifaRepository
    {
        Task<TarifaModel?> GetById(int id);
        Task Save(List<TarifaModel> tarifas, int idFuente);
    }
}
