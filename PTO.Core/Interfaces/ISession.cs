using System;

namespace PTO.Core.Interfaces
{
    public interface ISession<T> : IDisposable where T : IUnitOfWork
    {
        T GetUnitOfWork();
        void Complete();
        void Reset();
    }
}
