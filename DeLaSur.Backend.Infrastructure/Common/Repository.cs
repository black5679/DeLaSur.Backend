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
        protected Repository(IUnitOfWork unitOfWork)
        {
            Connection = unitOfWork.Connection;
            Transaction = unitOfWork.Transaction;
            IdUsuario = unitOfWork.IdUsuario;
        }
    }
}
