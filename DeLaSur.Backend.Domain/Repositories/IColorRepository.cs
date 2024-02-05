using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IColorRepository
    {
        Task<int> Insert(ColorModel color);
    }
}
