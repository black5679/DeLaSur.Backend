using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IMateriaPrimaRepository
    {
        Task<MateriaPrimaModel> GetById(int id);
    }
}
