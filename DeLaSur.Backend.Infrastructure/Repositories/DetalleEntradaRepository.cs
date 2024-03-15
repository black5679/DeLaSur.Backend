using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class DetalleEntradaRepository : Repository, IDetalleEntradaRepository
    {
        public DetalleEntradaRepository(IDbSession db) : base(db) { }
    }
}
