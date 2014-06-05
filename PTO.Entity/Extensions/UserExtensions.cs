using PTO.Core.Enums;
using PTO.Core.Extensions;
using PTO.Entity.Renweb;
using System;
using System.Linq;

namespace PTO.Entity.Extensions
{
    public static class UserExtensions
    {
        public static User MergeUserDetailsFromRenwebFamilyMember(this User user, RenwebFamilyMembersResult renweb)
        {
            if (renweb == null)
                return user;

            // Renweb data contains an asterisk at times so just remove it if it exists.
            var renwebFirstName = renweb.FirstName.Replace("*", string.Empty);
            var renwebLastName = renweb.LastName.Replace("*", string.Empty);

            user.FirstName = renwebFirstName.HasValue() ? renwebFirstName : null;
            user.LastName = renwebLastName.HasValue() ? renwebLastName : null;
            user.UserType = renweb.IsStudent ? UserType.Student : UserType.Parent;
            user.IsActive = user.Id.Equals(0) ? false : user.IsActive;

            if (renweb.AddressExists)
            {
                var exists = user.Addresses
                    .Any(x =>
                        (x.Line1 == null && renweb.Address == null) || (x.Line1 != null && x.Line1.Equals(renweb.Address)) &&
                        (x.Line2 == null && renweb.Address2 == null) || (x.Line2 != null && x.Line2.Equals(renweb.Address2)) &&
                        (x.City == null && renweb.City == null) || (x.City != null && x.City.Equals(renweb.City)) &&
                        (x.State == null && renweb.State == null) || (x.State != null && x.State.Equals(renweb.State)) &&
                        (x.Zip == null && renweb.Zip == null) || (x.Zip != null && x.Zip.Equals(renweb.Zip)) &&
                        (x.ZipLocation == null && renweb.ZipLocation == null) || (x.ZipLocation != null && x.ZipLocation.Equals(renweb.ZipLocation)) &&
                        (x.Country == null && renweb.Country == null) || (x.Country != null && x.Country.Equals(renweb.Country))
                    );
                if (!exists)
                    user.Addresses.Add(new UserAddress
                    {
                        Line1 = renweb.Address.HasValue() ? renweb.Address.Trim() : null,
                        Line2 = renweb.Address2.HasValue() ? renweb.Address2.Trim() : null,
                        City = renweb.City.HasValue() ? renweb.City.Trim() : null,
                        State = renweb.State.HasValue() ? renweb.State.Trim() : null,
                        Zip = renweb.Zip.HasValue() ? renweb.Zip.Trim() : null,
                        ZipLocation = renweb.ZipLocation.HasValue() ? renweb.ZipLocation.Trim() : null,
                        Country = renweb.Country.HasValue() ? renweb.Country.Trim() : null,
                        IsPrimary = !user.Addresses.Any()
                    });
            }

            if (renweb.Home.HasValue())
            {
                var exists = user.Phones
                    .Any(x =>
                        (x.Number == null && renweb.Home == null) || x.Number.Equals(renweb.Home.ExtractNumbers()) &&
                        x.Type.Equals(PhoneType.Home)
                    );
                if (!exists)
                    user.Phones.Add(new UserPhone
                    {
                        Number = renweb.Home.ExtractNumbers(),
                        Type = PhoneType.Home,
                        IsPrimary = !user.Phones.Any(x => x.Type == PhoneType.Cell || x.Type == PhoneType.Home)
                    });
            }

            if (renweb.Work.HasValue())
            {
                var exists = user.Phones
                    .Any(x =>
                        (x.Number == null && renweb.Home == null) || x.Number.Equals(renweb.Work.ExtractNumbers()) &&
                        x.Type.Equals(PhoneType.Work)
                    );
                if (!exists)
                    user.Phones.Add(new UserPhone
                    {
                        Number = renweb.Work.ExtractNumbers(),
                        Type = PhoneType.Work,
                        IsPrimary = !user.Phones.Any(x => x.Type == PhoneType.Cell || x.Type == PhoneType.Home)
                    });
            }

            if (renweb.Other.HasValue())
            {
                var exists = user.Phones
                    .Any(x =>
                        (x.Number == null && renweb.Other == null) || x.Number.Equals(renweb.Other.ExtractNumbers()) &&
                        x.Type.Equals(PhoneType.Other)
                    );
                if (!exists)
                    user.Phones.Add(new UserPhone
                    {
                        Number = renweb.Other.ExtractNumbers(),
                        Type = PhoneType.Other,
                        IsPrimary = !user.Phones.Any(x => x.Type == PhoneType.Cell || x.Type == PhoneType.Home)
                    });
            }

            if (renweb.Email.HasValue())
            {
                var exists = user.Emails
                    .Any(x => (x.Address == null && renweb.Email == null) || x.Address.Equals(renweb.Email));
                if (!exists)
                    user.Emails.Add(new UserEmail
                    {
                        Address = renweb.Email.Trim(),
                        IsPrimary = !user.Emails.Any()
                    });
            }

            return user;
        }
    }
}
