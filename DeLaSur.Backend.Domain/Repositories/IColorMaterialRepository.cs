using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IColorMaterialRepository
    {
        Task Save(List<int> colores, int idMaterial, int usuarioCreacion);
    }
}
