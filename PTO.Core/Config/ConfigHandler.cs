using System.Configuration;
using System.Web.Configuration;
using System.Xml;

namespace PTO.Core.Config
{
    public class ConfigSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            return new AppConfigData(section);
        }
    }

    public abstract class AppConfig
    {
        private static AppConfigData _config;
        private static string _applicationRoot;

        public static AppConfigData Current
        {
            get
            {
                if (_config != null)
                {
                    return _config;
                }

                AppConfigData config = (AppConfigData)WebConfigurationManager.GetSection("PTO.web") ?? (AppConfigData)ConfigurationManager.GetSection("PTO.web");

                if (config == null)
                {
                    _config = new AppConfigData();
                    config = _config;
                }

                return config;
            }
        }

        public static string ApplicationRoot
        {
            get { return _applicationRoot ?? (_applicationRoot = System.Web.Hosting.HostingEnvironment.MapPath("~/")); }
        }
    }
}
