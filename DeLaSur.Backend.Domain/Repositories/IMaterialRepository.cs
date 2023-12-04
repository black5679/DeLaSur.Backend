using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IMaterialRepository
    {
        Task<MaterialModel> GetById(int id);
    }
}
