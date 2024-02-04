using System.Data;
using System.Data.Common;

namespace DeLaSur.Backend.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        bool Commit();

        void Rollback();
    }
}
