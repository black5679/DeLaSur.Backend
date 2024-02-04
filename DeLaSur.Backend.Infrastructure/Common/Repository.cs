using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.Common
{
    public abstract class Repository
    {
        protected readonly IDbConnection Connection;
        protected readonly IDbTransaction? Transaction;
        protected readonly int IdUsuario;
        protected Repository(IDbSession db)
        {
            Connection = db.Connection;
            Transaction = db.Transaction;
            IdUsuario = db.IdUsuario;
        }
    }
}
