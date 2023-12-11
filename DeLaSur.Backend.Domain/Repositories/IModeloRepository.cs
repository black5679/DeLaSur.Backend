using DeLaSur.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IModeloRepository
    {
        Task Save(List<string> modelos, int idMaterial, int usuarioCreacion);
        Task<int> Insert(ModeloModel modelo);
    }
}
