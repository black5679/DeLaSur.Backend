using DeLaSur.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IMaterialBovedaRepository
    {
        Task<int> Save(List<MaterialBovedaModel> materialesBoveda, int usuarioCreacion);
    }
}
