using DeLaSur.Backend.Domain.Models;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface ICategoriaMateriaPrimaRepository
    {
        Task<IEnumerable<CategoriaMateriaPrimaModel>> GetByIdTipoMateriaPrima(int idTipoMateriaPrima);
    }
}
