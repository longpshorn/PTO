using PTO.Core.Enums;
using PTO.Core.Formatters;
using PTO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTO.Web.Models
{
    public class AddressViewModel : IAddress
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string FamilyMembers { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string ZipLocation { get; set; }

        public string Country { get; set; }

        public string Formatted { get { return AddressFormatter.Format(this);  } }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsActive { get; set; }

        public AddressType Type { get; set; }
    }
}