using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTO.Entity;

namespace PTO.Infrastructure.Mapping
{
    public class UserEmailMap : AuditEntityMap<UserEmail, int>
    {
        public UserEmailMap()
        {
            ToTable("UserEmail");

            Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(254)
                .HasColumnName("Address");

            Property(x => x.IsPrimary)
                .HasColumnName("IsPrimary")
                .IsRequired();

            Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();

            Property(x => x.Type)
                .HasColumnName("UserEmailTypeId")
                .IsRequired();

            // Relationships
            HasRequired(x => x.User)
                .WithMany(x => x.Emails)
                .Map(x => x.MapKey("UserId"));
        }
    }
}
