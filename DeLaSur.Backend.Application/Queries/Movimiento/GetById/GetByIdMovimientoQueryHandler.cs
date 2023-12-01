using DeLaSur.Backend.Domain.Exceptions;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Queries.Movimiento.GetById
{
    public class GetByIdMovimientoQueryHandler : IRequestHandler<GetByIdMovimientoQuery, GetByIdMovimientoResponse>
    {
        private readonly IDb db;
        private readonly IMovimientoRepository movimientoRepository;
        private readonly IDetalleMovimientoRepository detalleMovimientoRepository;
        public GetByIdMovimientoQueryHandler(IDb db)
        {
            this.db = db;
            movimientoRepository = new MovimientoRepository(db.Connection, null);
            detalleMovimientoRepository = new DetalleMovimientoRepository(db.Connection, null);
        }
        public async Task<GetByIdMovimientoResponse> Handle(GetByIdMovimientoQuery request, CancellationToken cancellationToken)
        {
            var movimiento = await movimientoRepository.GetById(request.Id) ?? throw new NotFoundException("No se encontró el movimiento");
            var response = movimiento.Adapt<GetByIdMovimientoResponse>();
            var detallesMovimiento = await detalleMovimientoRepository.GetByIdMovimiento(request.Id);
            response.DetallesMovimiento = detallesMovimiento.Adapt<IEnumerable<DetalleMovimiento>>();
            return response;
        }
    }
}
