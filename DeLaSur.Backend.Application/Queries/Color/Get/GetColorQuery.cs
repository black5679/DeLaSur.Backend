using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.Color.Get
{
    public class GetColorQuery : IRequest<IEnumerable<GetColorResponse>>
    {
    }
}
