using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IInventarioRepository
    {
        Task<IEnumerable<InventarioModel>> Get();
    }
}
