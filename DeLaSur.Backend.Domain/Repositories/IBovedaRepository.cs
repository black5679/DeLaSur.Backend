using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IBovedaRepository
    {
        Task<int> Insert(BovedaModel boveda);
    }
}
