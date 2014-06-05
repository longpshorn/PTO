using PTO.Core.Config;
using PTO.Core.Exceptions;
using PTO.Core.Interfaces;
using PTO.Core.Logging;
using System;
using System.Data.Entity.Infrastructure;

namespace PTO.Infrastructure
{
    /// <summary>
    /// The DbSession class is used to prevent a repository from maintaining a direct relationship with an
    /// <see cref="PTO.Core.Interfaces.IUnitOfWork"/> instance. When a repository is instantiated, it recieves a session for
    /// the type of IUnitOfWork (i.e., <see cref="System.Data.Entity.DbContext"/>) it needs from either an existing
    /// <see cref="PTO.Core.Interfaces.IUnitOfWork"/> or a new one that is created on-the-fly for it. That repository
    /// instance however will not be tightly coupled to the instance of that <see cref="PTO.Core.Interfaces.IUnitOfWork"/>.
    /// 
    /// In this way, the <see cref="PTO.Core.Interfaces.IUnitOfWork"/> exists outside of the lifetime and usefulness of the
    /// repository and can be reused across repository boundaries, if necessary.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="PTO.Core.Interfaces.IUnitOfWork"/> (i.e., DbContext) that this session will retain.</typeparam>
    public class DbSession<T> : ISession<T> where T : IUnitOfWork
    {
        private const string _unenlistedErrorMessage = "Unit of work of type {0} has not been assigned.";

        private T _unitOfWork;

        public DbSession(T unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public T GetUnitOfWork()
        {
            if (_unitOfWork == null)
            {
                throw new InvalidOperationException(string.Format(_unenlistedErrorMessage, typeof(T).ToString()));
            }

            return _unitOfWork;
        }

        public void Complete()
        {
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException cex)
            {
                throw new DatabaseUpdateConcurrencyException(cex.Message, cex);
            }
            catch (Exception ex)
            {
                AppLogger.Current.Error(ex);
                if (!AppConfig.Current.Environment.Environment.Equals(PTO.Core.Enums.Environment.Prod))
                    throw ex;
            }
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Reset()
        {
            Dispose();
            _unitOfWork = default(T); // default(T) is null for a reference time which IUnitOfWork will be
        }
    }
}
