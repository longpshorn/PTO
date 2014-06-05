using PTO.Core.Entities;
using System;

namespace PTO.Entity.Logging
{
    public class Log : EntityBase<Log, long>
    {
        public DateTime LogDateTime { get; set; }

        public string MachineName { get; set; }

        public string Identity { get; set; }

        public string LoggerName { get; set; }

        public string LogLevel { get; set; }

        public string Message { get; set; }

        public string ExceptionSource { get; set; }

        public string ExceptionClass { get; set; }

        public string ExceptionMethod { get; set; }

        public string ExceptionError { get; set; }

        public string ExceptionStackTrace { get; set; }

        public string ExceptionInnerMessage { get; set; }
    }
}
