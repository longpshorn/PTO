using System;
using NLog;
using Microsoft.Practices.ServiceLocation;
using PTO.Core.Interfaces;

namespace PTO.Core.Logging
{
    public class LogManagerFactory : IFactory<ILogManager>
    {
        public ILogManager Create()
        {
            return NLogManager.GetLoggingService();
        }

        public static ILogManager Get()
        {
            return ServiceLocator.Current.GetInstance<ILogManager>();
        }
    }

    internal class NLogManager : Logger, ILogManager
    {
        private const string LoggerName = "NLogManager";

        public static ILogManager GetLoggingService()
        {
            return (ILogManager)LogManager.GetLogger(LoggerName, typeof(NLogManager));
        }

        public void SetGlobalContextField(string item, string value)
        {
            GlobalDiagnosticsContext.Set(item, value);
        }

        public void SetMappedContextField(string item, string value)
        {
            MappedDiagnosticsContext.Set(item, value);
        }

        public void Trace(Exception exception)
        {
            Trace(exception, string.Empty);
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            if (!IsTraceEnabled)
                return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Trace, exception, format, args);
            Log(typeof(NLogManager), logEvent);
        }

        public void Debug(Exception exception)
        {
            Debug(exception, string.Empty);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            if (!IsDebugEnabled)
                return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Debug, exception, format, args);
            Log(typeof(NLogManager), logEvent);
        }

        public void Info(Exception exception)
        {
            Info(exception, string.Empty);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            if (!IsInfoEnabled)
                return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Info, exception, format, args);
            Log(typeof(NLogManager), logEvent);
        }

        public void Warn(Exception exception)
        {
            Warn(exception, string.Empty);
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            if (!IsWarnEnabled)
                return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Warn, exception, format, args);
            Log(typeof(NLogManager), logEvent);
        }

        public void Error(Exception exception)
        {
            Error(exception, string.Empty);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            if (!IsErrorEnabled)
                return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Error, exception, format, args);
            Log(typeof(NLogManager), logEvent);
        }

        public void Fatal(Exception exception)
        {
            Fatal(exception, string.Empty);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            if (!IsFatalEnabled)
                return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Fatal, exception, format, args);
            Log(typeof(NLogManager), logEvent);
        }

        private static LogEventInfo GetLogEvent(string loggerName, LogLevel level, Exception exception, string format, object[] args)
        {
            var logEvent = new LogEventInfo(level, loggerName, null, string.Format(format, args), null, exception);

            var exceptionSource = string.Empty;
            var exceptionClass = string.Empty;
            var exceptionMethod = string.Empty;
            var exceptionError = string.Empty;
            var exceptionStackTrace = string.Empty;
            var exceptionInnerMessage = string.Empty;

            if (exception != null)
            {
                exceptionSource = exception.Source;
                if (exception.TargetSite.DeclaringType != null)
                {
                    exceptionClass = exception.TargetSite.DeclaringType.FullName;
                }
                exceptionMethod = exception.TargetSite.Name;
                exceptionError = exception.Message;
                exceptionStackTrace = exception.StackTrace;
                exceptionInnerMessage = GetInnerMessage(exception);
            }

            logEvent.Properties["ExceptionSource"] = exceptionSource;
            logEvent.Properties["ExceptionClass"] = exceptionClass;
            logEvent.Properties["ExceptionMethod"] = exceptionMethod;
            logEvent.Properties["ExceptionError"] = exceptionError;
            logEvent.Properties["ExceptionStackTrace"] = exceptionStackTrace;
            logEvent.Properties["ExceptionInnerMessage"] = exceptionInnerMessage;

            return logEvent;
        }

        private static string GetInnerMessage(Exception exception)
        {
            var returnValue = string.Empty;

            if (exception.InnerException != null)
            {
                returnValue = exception.InnerException.Message;
            }

            return returnValue;
        }
    }
}
