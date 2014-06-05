using PTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping
{
    public class UserAccountInfoMap : AuditEntityMap<UserAccountInfo, int>
    {
        public UserAccountInfoMap()
        {
            ToTable("UserAccountInfo");

            Property(x => x.LoginEmail)
                .HasColumnName("LoginEmail")
                .IsRequired()
                .HasMaxLength(254);

            Property(x => x.IsValidLoginEmail)
                .HasColumnName("IsValidLoginEmail");

            Property(x => x.Password)
                 .HasColumnName("Password")
                 .IsRequired()
                 .HasMaxLength(1000);

            Property(x => x.Salt)
                .HasColumnName("Salt")
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.LastLoginDate)
                .HasColumnName("LastLoginDate");

            Property(x => x.LoginCount)
                .HasColumnName("LoginCount")
                .IsRequired();
        }
    }
}
