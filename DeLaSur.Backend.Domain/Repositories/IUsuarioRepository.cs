using DeLaSur.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioModel>> Get();
        Task<UsuarioModel> GetById(int id);
        Task<int> Insert(UsuarioModel usuario);
        Task<int> Update(UsuarioModel usuario);
        Task<int> Delete(UsuarioModel usuario);
    }
}
