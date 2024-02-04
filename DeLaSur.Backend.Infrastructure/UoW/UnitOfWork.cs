using DeLaSur.Backend.Domain.UoW;
using System.Data;
using System.Data.Common;

namespace DeLaSur.Backend.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly IDbSession _dbSession;

        public UnitOfWork(IDbSession dbSession)
        {
            _dbSession = dbSession;
            _disposed = false;
            BeginTransaction();
        }
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_dbSession.Connection.State != ConnectionState.Open)
            {
                _dbSession.Connection.Open();
            }

            _dbSession.Transaction = (DbTransaction)_dbSession.Connection.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            if (_dbSession.Transaction?.Connection == null)
            {
                return false;
            }

            _dbSession.Transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            if (_dbSession.Transaction?.Connection != null)
            {
                _dbSession.Transaction.Rollback();
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing && _dbSession != null)
            {
                _dbSession.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
