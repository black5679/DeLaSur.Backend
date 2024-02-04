using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface ISubCategoriaMateriaPrimaRepository
    {
        Task<IEnumerable<SubCategoriaMateriaPrimaModel>> GetByIdCategoriaMateriaPrima(int idCategoriaMateriaPrima);
    }
}
