using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTO.Entity;

namespace PTO.Infrastructure.Mapping
{
    public class UserAddressMap : AuditEntityMap<UserAddress, int>
    {
        public UserAddressMap()
        {
            // Table & Column Mappings
            ToTable("UserAddress");

            // Properties
            Property(x => x.Type)
                .HasColumnName("UserAddressTypeId")
                .IsRequired();

            Property(x => x.Line1)
                .HasColumnName("Line1")
                .IsOptional()
                .HasMaxLength(100);

            Property(x => x.Line2)
                .HasColumnName("Line2")
                .IsOptional()
                .HasMaxLength(100);

            Property(x => x.City)
                .HasColumnName("City")
                .IsOptional()
                .HasMaxLength(100);

            Property(x => x.State)
                .HasColumnName("State")
                .IsOptional()
                .IsFixedLength()
                .HasMaxLength(50);

            Property(x => x.Zip)
                .HasColumnName("Zip")
                .IsOptional()
                .IsFixedLength()
                .HasMaxLength(20);

            Property(x => x.ZipLocation)
                .HasColumnName("ZipLocation")
                .IsOptional()
                .IsFixedLength()
                .HasMaxLength(10);

            Property(x => x.Country)
                .HasColumnName("Country")
                .IsOptional()
                .HasMaxLength(200);

            Property(x => x.Location)
                .HasColumnName("Location")
                .IsOptional();

            Property(x => x.IsPrimary)
                .HasColumnName("IsPrimary")
                .IsRequired();

            Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();

            // Relationships
            HasRequired(x => x.User)
                .WithMany(x => x.Addresses)
                .Map(x => x.MapKey("UserId"));
        }
    }
}
