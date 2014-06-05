using System.Xml.XPath;
using PTO.Core.Extensions;

namespace PTO.Core.Config
{
    public class ConstantsConfig : IConstantsConfig
    {
        private int _minimumYear;
        private int _registrationWindowDays;
        private string _googleMapsApiKey;

        private readonly IConstantsConfig _template;

        public ConstantsConfig(XPathNavigator nav, IConstantsConfig template)
        {
            _template = template;

            if (_template != null)
            {
                _minimumYear = _template.MinimumYear;
                _registrationWindowDays = _template.RegistrationWindowDays;
                _googleMapsApiKey = _template.GoogleMapsApiKey;
            }

            SetMinimumYear(nav.Select("minimumYear"));
            SetRegistrationWindowDays(nav.Select("registrationWindowDays"));
            SetGoogleMapsApiKey(nav.Select("googleMapsApiKey"));
        }

        public int MinimumYear
        {
            get { return _minimumYear; }
        }

        public int RegistrationWindowDays
        {
            get { return _registrationWindowDays; }
        }

        public string GoogleMapsApiKey
        {
            get { return _googleMapsApiKey; }
        }

        private void SetMinimumYear(XPathNodeIterator iter)
        {
            if (iter.MoveNext())
            {
                var value = iter.Current.GetAttribute("value", string.Empty);
                if (value.HasValue())
                    _minimumYear = int.Parse(value);
            }
        }

        private void SetRegistrationWindowDays(XPathNodeIterator iter)
        {
            if (iter.MoveNext())
            {
                var value = iter.Current.GetAttribute("value", string.Empty);
                if (value.HasValue())
                    _registrationWindowDays = int.Parse(value);
            }
        }

        private void SetGoogleMapsApiKey(XPathNodeIterator iter)
        {
            if (iter.MoveNext())
            {
                var value = iter.Current.GetAttribute("value", string.Empty);
                if (value.HasValue())
                    _googleMapsApiKey = value;
            }
        }
    }
}
