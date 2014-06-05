using PTO.Core.Interfaces;

namespace PTO.Core.Logging
{
    public static class AppLogger
    {
        public static ILogManager Current
        {
            get { return LogManagerFactory.Get(); }
        }
    }
}
