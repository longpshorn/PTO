using System;

namespace PTO.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
