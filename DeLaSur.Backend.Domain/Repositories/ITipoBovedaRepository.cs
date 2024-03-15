using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface ITipoBovedaRepository
    {
        Task<IEnumerable<TipoBovedaModel>> Get();
    }
}
