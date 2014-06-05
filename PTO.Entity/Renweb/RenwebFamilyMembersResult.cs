using PTO.Core.Entities;
using PTO.Core.Extensions;

namespace PTO.Entity.Renweb
{
    public class RenwebFamilyMembersResult : AuditEntity<RenwebFamilyMembersResult, int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Home { get; set; }

        public string Work { get; set; }

        public string Other { get; set; }

        public string Address { get; set; }

        public string CSZ { get; set; }

        public string Address2 { get; set; }

        public string Country { get; set; }

        public string Photo { get; set; }

        public string ActiveTab { get; set; }

        public int StudentEntry { get; set; }

        public string Email { get; set; }

        public bool PicResized { get; set; }

        public bool IsProcessed { get; set; }

        public bool IsStudent
        {
            get
            {
                return StudentEntry.Equals(1);
            }
        }

        public bool IsActive
        {
            get
            {
                return ActiveTab.Equals("1");
            }
        }

        public string City
        {
            get
            {
                var cityState = ExtractCityStateFromCSZ();
                return cityState.HasValue()
                    ? cityState.Split(',')[0].Trim()
                    : null;
            }
        }

        public string State
        {
            get
            {
                var cityState = ExtractCityStateFromCSZ();
                if (cityState.HasValue())
                {
                    var state = cityState.Split(',')[1].Trim();
                    return RenwebStateLookpup.Find(state);
                }
                return null;
            }
        }

        public string Zip
        {
            get
            {
                var zip = CSZ.ExtractNumbers();
                return zip.HasValue()
                    ? zip.Left(6)
                    : null;
            }
        }

        public string ZipLocation
        {
            get
            {
                var zip = CSZ.ExtractNumbers();
                return zip.HasValue() && zip.Length >= 6
                    ? zip.TrimStartLength(5)
                    : null;
            }
        }

        public bool AddressExists
        {
            get
            {
                return Address.HasValue()
                    || Address2.HasValue()
                    || CSZ.HasValue()
                    || Country.HasValue();
            }
        }

        private string ExtractCityStateFromCSZ()
        {
            return CSZ.ExtractCharacters()
                .Replace(",,", ",")
                .Replace(", ,", ",");
        }
    }
}
