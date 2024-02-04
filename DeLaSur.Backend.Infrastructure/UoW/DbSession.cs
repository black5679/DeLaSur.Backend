using DeLaSur.Backend.Domain.UoW;
using System.Data;
using System.Data.Common;

namespace DeLaSur.Backend.Infrastructure.UoW
{
    public class DbSession : IDbSession
    {
        private readonly IDb _db;
        public IDbTransaction? Transaction { get; set; }

        public IDbConnection Connection => _db.Connection;
        public int IdUsuario { get; set; }

        private bool _disposed;
        public DbSession(IDb db)
        {
            _db = db;
            _disposed = false;
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing && _db != null)
            {
                if (_db.Connection.State == ConnectionState.Open)
                {
                    _db.Connection.Close();
                }

                if (Transaction?.Connection != null)
                {
                    ((IDisposable)Transaction).Dispose();
                }
                _db.Dispose();
            }

            _disposed = true;
        }
    }
}
