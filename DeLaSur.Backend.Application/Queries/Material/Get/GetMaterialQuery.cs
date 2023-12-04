using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.Material.Get
{
    public class GetMaterialQuery : IRequest<IEnumerable<GetMaterialResponse>>
    {
    }
}
