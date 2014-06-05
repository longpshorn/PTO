using PTO.Entity.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping.Logging
{
    public class LogMap : EntityBaseMap<Log, long>
    {
        public LogMap()
        {
            ToTable("Log");

            Property(x => x.LogDateTime)
                .HasColumnName("LogDateTime")
                .IsRequired();

            Property(x => x.MachineName)
                .HasColumnName("MachineName")
                .HasMaxLength(50);

            Property(x => x.Identity)
                .HasColumnName("Identity")
                .HasMaxLength(100);

            Property(x => x.LoggerName)
                .HasColumnName("LoggerName")
                .HasMaxLength(200);

            Property(x => x.LogLevel)
                .HasColumnName("LogLevel")
                .HasMaxLength(20);

            Property(x => x.Message)
                .HasColumnName("Message")
                .IsMaxLength();

            Property(x => x.ExceptionSource)
                .HasColumnName("ExceptionSource")
                .HasMaxLength(200);

            Property(x => x.ExceptionClass)
                .HasColumnName("ExceptionClass")
                .HasMaxLength(200);

            Property(x => x.ExceptionMethod)
                .HasColumnName("ExceptionMethod")
                .HasMaxLength(200);

            Property(x => x.ExceptionError)
                .HasColumnName("ExceptionError")
                .HasMaxLength(1000);

            Property(x => x.ExceptionStackTrace)
                .HasColumnName("ExceptionStackTrace")
                .IsMaxLength();

            Property(x => x.ExceptionInnerMessage)
                .HasColumnName("ExceptionInnerMessage")
                .IsMaxLength();
        }
    }
}
