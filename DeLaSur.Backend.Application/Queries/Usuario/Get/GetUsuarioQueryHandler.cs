using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Queries.Usuario.Get
{
    public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, IEnumerable<GetUsuarioResponse>>
    {
        private readonly IUsuarioRepository usuarioRepository;
        public GetUsuarioQueryHandler(IDb db)
        {
            usuarioRepository = new UsuarioRepository(db.Connection, null);
        }
        public async Task<IEnumerable<GetUsuarioResponse>> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await usuarioRepository.Get();
            var response = usuarios.Adapt<IEnumerable<GetUsuarioResponse>>();
            return response;
        }
    }
}
