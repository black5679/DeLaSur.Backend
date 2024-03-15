using MediatR;
using DeLaSur.Backend.Domain.Repositories;
using Mapster;

namespace DeLaSur.Backend.Application.Queries.CategoriaMateriaPrima.GetByIdTipoMateriaPrima
{
    public class GetByIdTipoMateriaPrimaCategoriaMateriaPrimaQueryHandler : IRequestHandler<GetByIdTipoMateriaPrimaCategoriaMateriaPrimaQuery, IEnumerable<GetByIdTipoMateriaPrimaCategoriaMateriaPrimaResponse>>
    {
        private readonly ICategoriaMateriaPrimaRepository categoriaMateriaPrimaRepository;
        public GetByIdTipoMateriaPrimaCategoriaMateriaPrimaQueryHandler(ICategoriaMateriaPrimaRepository categoriaMateriaPrimaRepository)
        {
            this.categoriaMateriaPrimaRepository = categoriaMateriaPrimaRepository;
        }
        public async Task<IEnumerable<GetByIdTipoMateriaPrimaCategoriaMateriaPrimaResponse>> Handle(GetByIdTipoMateriaPrimaCategoriaMateriaPrimaQuery request, CancellationToken cancellationToken)
        {
            var categorias = await categoriaMateriaPrimaRepository.GetByIdTipoMateriaPrima(request.IdTipoMateriaPrima);
            var response = categorias.Adapt<IEnumerable<GetByIdTipoMateriaPrimaCategoriaMateriaPrimaResponse>>();
            return response;
        }
    }
}
