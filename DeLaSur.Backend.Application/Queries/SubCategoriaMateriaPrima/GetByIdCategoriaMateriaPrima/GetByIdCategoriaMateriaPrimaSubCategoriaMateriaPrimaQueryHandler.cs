using DeLaSur.Backend.Domain.UoW;
using MediatR;
using DeLaSur.Backend.Domain.Repositories;
using Mapster;

namespace DeLaSur.Backend.Application.Queries.SubCategoriaMateriaPrima.GetByIdCategoriaMateriaPrima
{
    public class GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaQueryHandler : IRequestHandler<GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaQuery, IEnumerable<GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaResponse>>
    {
        private readonly ISubCategoriaMateriaPrimaRepository subCategoriaMateriaPrimaRepository;
        public GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaQueryHandler(ISubCategoriaMateriaPrimaRepository subCategoriaMateriaPrimaRepository)
        {
            this.subCategoriaMateriaPrimaRepository = subCategoriaMateriaPrimaRepository;
        }
        public async Task<IEnumerable<GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaResponse>> Handle(GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaQuery request, CancellationToken cancellationToken)
        {
            var subCategorias = await subCategoriaMateriaPrimaRepository.GetByIdCategoriaMateriaPrima(request.IdCategoriaMateriaPrima);
            var response = subCategorias.Adapt<IEnumerable<GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaResponse>>();
            return response;
        }
    }
}
