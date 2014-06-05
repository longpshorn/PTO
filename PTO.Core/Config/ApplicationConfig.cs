using System.Xml.XPath;
using PTO.Core.Extensions;

namespace PTO.Core.Config
{
    public class ApplicationConfig : IApplicationConfig
    {
        private int _cacheExpiry;
        private int _loginExpiry;
        private int _persistentCookieExpiryDays;
        private string _dynamicFileDirectory;
        private IApplicationData _data;

        private readonly XPathNavigator _nav;
        private readonly IApplicationConfig _template;

        public ApplicationConfig(XPathNavigator nav, IApplicationConfig template)
        {
            _template = template;

            if (_template != null)
            {
                _cacheExpiry = _template.CacheExpiry;
                _loginExpiry = _template.LoginExpiry;
                _persistentCookieExpiryDays = _template.PersistentCookieExpiryDays;
                _dynamicFileDirectory = _template.DynamicFileDirectory;
            }

            SetLoginExpiry(nav);
            SetPersistentCookieExpiryDays(nav);
            SetCacheExpiry(nav);
            SetDynamicFileDirectory(nav);

            _nav = nav;
        }

        public int CacheExpiry
        {
            get { return _cacheExpiry; }
        }

        public int LoginExpiry
        {
            get { return _loginExpiry; }
        }

        public int PersistentCookieExpiryDays
        {
            get { return _persistentCookieExpiryDays; }
        }

        public string DynamicFileDirectory
        {
            get { return _dynamicFileDirectory; }
        }

        public IApplicationData Data
        {
            get { return _data ?? (_data = new ApplicationData(_nav.Select("data"), _template != null ? _template.Data : null)); }
        }

        private void SetLoginExpiry(XPathNavigator nav)
        {
            var value = nav.GetAttribute("loginExpiry", string.Empty);
            if (value.HasValue())
                _loginExpiry = int.Parse(value);
        }

        private void SetPersistentCookieExpiryDays(XPathNavigator nav)
        {
            var value = nav.GetAttribute("persistentCookieExpiryDays", string.Empty);
            if (value.HasValue())
                _persistentCookieExpiryDays = int.Parse(value);
        }

        private void SetCacheExpiry(XPathNavigator nav)
        {
            var value = nav.GetAttribute("cacheExpiry", string.Empty);
            if (value.HasValue())
                _cacheExpiry = int.Parse(value);
        }

        private void SetDynamicFileDirectory(XPathNavigator nav)
        {
            var value = nav.GetAttribute("dynamicFileDirectory", string.Empty);
            if (value.HasValue())
                _dynamicFileDirectory = value;
        }
    }

    public class ApplicationData : IApplicationData
    {
        private readonly bool _automaticValidateOnSaveEnabled;

        public ApplicationData(XPathNodeIterator iter, IApplicationData template)
        {
            if (template != null)
            {
                _automaticValidateOnSaveEnabled = template.AutomaticValidateOnSaveEnabled;
            }

            if (iter.MoveNext())
            {
                _automaticValidateOnSaveEnabled = bool.Parse(iter.Current.GetAttribute("automaticValidateOnSaveEnabled", string.Empty));
            }
        }

        public bool AutomaticValidateOnSaveEnabled
        {
            get { return _automaticValidateOnSaveEnabled; }
        }
    }
}
