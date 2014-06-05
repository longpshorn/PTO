using PTO.Core.Enums;
using PTO.Core.Entities;
using PTO.Core.Extensions;
using PTO.Core.Interfaces;
using System.Data.Entity.Spatial;
using System.Text;
using PTO.Core.Formatters;

namespace PTO.Entity
{
    public class UserAddress : AuditEntity<UserAddress, int>, IAddress
    {
        public UserAddress()
            : base()
        {
            Type = AddressType.Home;
            IsPrimary = true;
            IsActive = true;
        }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string ZipLocation { get; set; }

        public string Country { get; set; }

        public DbGeography Location { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsActive { get; set; }

        public AddressType Type { get; set; }

        public virtual User User { get; set; }

        public string Formatted
        {
            get
            {
                return AddressFormatter.Format(this);
            }
        }

        public override string ToString()
        {
            return AddressFormatter.Format(this);
        }

        public void UpdateLocation(double latitude, double longitude)
        {
            Location = DbGeography.FromText(string.Format("POINT({1} {0})", latitude, longitude));
        }
    }
}
