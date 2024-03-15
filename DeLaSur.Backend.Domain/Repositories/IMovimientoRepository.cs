using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IMovimientoRepository
    {
        Task<MovimientoModel?> GetById(int id);
        Task<int> Insert(MovimientoModel movimiento);
    }
}
