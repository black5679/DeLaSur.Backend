using MediatR;

namespace DeLaSur.Backend.Application.Queries.Usuario.GetById
{
    public class GetByIdUsuarioQuery : IRequest<GetByIdUsuarioResponse>
    {
        public required int Id { get; set; }
    }
}
