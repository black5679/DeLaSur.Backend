using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Queries.Usuario.GetById
{
    public class GetByIdUsuarioQueryHandler : IRequestHandler<GetByIdUsuarioQuery, GetByIdUsuarioResponse>
    {
        private readonly IUsuarioRepository usuarioRepository;
        public GetByIdUsuarioQueryHandler(IDb db)
        {
            usuarioRepository = new UsuarioRepository(db.Connection, null);
        }
        public async Task<GetByIdUsuarioResponse> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await usuarioRepository.GetById(request.Id);
            var response = usuario.Adapt<GetByIdUsuarioResponse>();
            return response;
        }
    }
}
