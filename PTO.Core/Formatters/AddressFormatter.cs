using PTO.Core.Interfaces;
using PTO.Core.Extensions;
using System.Text;

namespace PTO.Core.Formatters
{
    public static class AddressFormatter
    {
        public static string Format(IAddress address)
        {
            return USFormat(address);
        }

        private static string USFormat(IAddress address)
        {
            var formatted = new StringBuilder();
            var empty = string.Empty;
            var space = " ";
            var comma = ", ";
            var hypen = "-";
            var separater = comma;

            formatted.AppendIfNotBlank(address.Line1.Trim());

            separater = formatted.Length > 0 ? comma : empty;
            formatted.AppendIfNotBlank(address.Line2.HasValue() ? separater + address.Line2.Trim() : empty);

            separater = formatted.Length > 0 ? comma : empty;
            formatted.AppendIfNotBlank(address.City.HasValue() ? separater + address.City.Trim() : empty);

            separater = formatted.Length > 0 ? comma : empty;
            formatted.AppendIfNotBlank(address.State.HasValue() ? separater + address.State.Trim() : empty);

            separater = formatted.Length > 0 ? space : empty;
            formatted.AppendIfNotBlank(address.Zip.HasValue() ? separater + address.Zip.Trim() : empty);

            if (address.Zip.HasValue())
                formatted.AppendIfNotBlank(address.ZipLocation.HasValue() ? hypen + address.ZipLocation.Trim() : empty);

            separater = formatted.Length > 0 ? comma : empty;
            formatted.AppendIfNotBlank(address.Country.HasValue() ? separater + address.Country.Trim() : empty);

            return formatted.ToString();
        }
    }
}
