using System;

namespace PTO.Core.Exceptions
{
    public class DatabaseUpdateConcurrencyException : Exception
    {
        public DatabaseUpdateConcurrencyException(string message) : base(message) { }
        public DatabaseUpdateConcurrencyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
