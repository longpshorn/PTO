using PTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping
{
    public class UserLoginMap : AuditEntityMap<UserLogin, int>
    {
        public UserLoginMap() {
            ToTable("UserLogin");

            Property(x => x.LoginAttemptCount)
                .HasColumnName("LoginAttemptCount")
                .IsRequired();

            Property(x => x.IpAddress)
                .HasColumnName("IpAddress")
                .IsRequired()
                .HasMaxLength(45);

            Property(x => x.LoginTime)
                .HasColumnName("LoginTime");

            Property(x => x.LogoutTime)
                .HasColumnName("LogoutTime");

            // Relationships
            HasRequired(x => x.User)
                .WithMany(x => x.Logins)
                .Map(x => x.MapKey("UserId"));
        }
    }
}
