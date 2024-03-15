using DeLaSur.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IDetalleCompraRepository
    {
        Task Save(List<DetalleCompraModel> detallesCompra, int idCompra);
    }
}
