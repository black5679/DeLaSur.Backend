using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.Movimiento.GetById
{
    public class GetByIdMovimientoQuery : IRequest<GetByIdMovimientoResponse>
    {
        public required int Id { get; set; }
    }
}
