using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTO.Entity;

namespace PTO.Infrastructure.Mapping
{
    public class UserMap : AuditEntityMap<User, int>
    {
        public UserMap()
        {
            ToTable("User");

            Ignore(x => x.IsAuthenticated);

            Property(x => x.UserType)
                .HasColumnName("UserTypeId")
                .IsRequired();

            Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .IsOptional()
                .HasMaxLength(100);

            Property(x => x.MiddleName)
                .HasColumnName("MiddleName")
                .IsOptional()
                .HasMaxLength(1);

            Property(x => x.LastName)
                .HasColumnName("LastName")
                .IsOptional()
                .HasMaxLength(100);

            Property(x => x.ImageData)
                .HasColumnName("ImageData")
                .IsOptional()
                .HasMaxLength(Int32.MaxValue);

            Property(x => x.ImageMimeType)
                .HasColumnName("ImageMimeType")
                .IsOptional()
                .HasMaxLength(50);

            Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();

            // Navigation properties
            HasOptional(x => x.AccountInfo)
                .WithRequired(x => x.User)
                .Map(x => x.MapKey("UserId"));

            HasMany(x => x.Addresses)
                .WithRequired(x => x.User)
                .Map(x => x.MapKey("UserId"));

            HasMany(x => x.Phones)
                .WithRequired(x => x.User)
                .Map(x => x.MapKey("UserId"));

            HasMany(x => x.Emails)
                .WithRequired(x => x.User)
                .Map(x => x.MapKey("UserId"));

            HasMany(x => x.Logins)
                .WithRequired(x => x.User)
                .Map(x => x.MapKey("UserId"));

            //HasRequired(x => x.Registration)
            //    .WithOptional(x => x.RegisteredUser)
            //    .Map(x => x.MapKey("RegistrationId"));
        }
    }
}
