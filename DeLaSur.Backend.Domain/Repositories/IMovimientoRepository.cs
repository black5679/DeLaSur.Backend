using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IMovimientoRepository
    {
        Task<int> Insert(MovimientoModel movimiento);
    }
}
