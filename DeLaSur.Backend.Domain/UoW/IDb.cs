using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.UoW
{
    public interface IDb : IDisposable
    {
        IDbConnection Connection { get; }
        void Connect();
    }
}
