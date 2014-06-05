using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTO.Entity;

namespace PTO.Infrastructure.Mapping
{
    public class UserPhoneMap : AuditEntityMap<UserPhone, int>
    {
        public UserPhoneMap()
        {
            ToTable("UserPhone");

            Property(x => x.Number)
                .HasColumnName("Number")
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Extension)
                .HasColumnName("Extension")
                .HasMaxLength(10);

            Property(x => x.IsPrimary)
                .HasColumnName("IsPrimary")
                .IsRequired();

            Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();

            Property(x => x.Type)
                .HasColumnName("UserPhoneTypeId")
                .IsRequired();

            // Relationships
            HasRequired(x => x.User)
                .WithMany(x => x.Phones)
                .Map(x => x.MapKey("UserId"));
        }
    }
}
