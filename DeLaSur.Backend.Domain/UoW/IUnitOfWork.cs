using System.Data;
using System.Data.Common;

namespace DeLaSur.Backend.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        int IdUsuario { get; set; }
        IDbTransaction Transaction { get; }

        IDbConnection Connection { get; }

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        bool Commit();

        void Rollback();
    }
}
