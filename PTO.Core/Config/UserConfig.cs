using System.Xml.XPath;
using PTO.Core.Extensions;

namespace PTO.Core.Config
{
    public class UserConfig : IUserConfig
    {
        private string _defaultImage;

        private readonly IUserConfig _template;

        public UserConfig(XPathNavigator nav, IUserConfig template)
        {
            _template = template;

            if (_template != null)
            {
                _defaultImage = _template.DefaultImage;
            }

            SetDefaultImage(nav);
        }

        public string DefaultImage
        {
            get { return _defaultImage; }
        }

        private void SetDefaultImage(XPathNavigator nav)
        {
            var value = nav.GetAttribute("defaultImage", string.Empty);

            if (value.HasValue())
            {
                _defaultImage = value;
            }
        }
    }
}
