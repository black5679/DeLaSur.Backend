using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.UoW
{
    public interface IDbSession : IDisposable
    {
        IDbTransaction? Transaction { get; set; }
        IDbConnection Connection { get; }
        int IdUsuario { get; set; }
    }
}
