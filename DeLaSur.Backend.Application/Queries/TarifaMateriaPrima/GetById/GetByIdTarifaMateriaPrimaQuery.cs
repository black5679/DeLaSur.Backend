using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.TarifaMateriaPrima.GetById
{
    public class GetByIdTarifaMateriaPrimaQuery : IRequest<GetByIdTarifaMateriaPrimaResponse>
    {
        public int Id { get; set; }
    }
}
