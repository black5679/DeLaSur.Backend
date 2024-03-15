using DeLaSur.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface ICompraRepository
    {
        Task<int> Insert(CompraModel compra);
        Task<int> Update(CompraModel compra);
    }
}
