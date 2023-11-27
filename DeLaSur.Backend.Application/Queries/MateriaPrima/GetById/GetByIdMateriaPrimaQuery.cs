using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.MateriaPrima.GetById
{
    public class GetByIdMateriaPrimaQuery : IRequest<GetByIdMateriaPrimaResponse>
    {
        public int Id { get; set; }
    }
}
