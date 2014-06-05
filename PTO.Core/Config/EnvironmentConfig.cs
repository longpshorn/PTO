using PTO.Core.Enums;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.XPath;

namespace PTO.Core.Config
{
    public class EnvironmentConfig : IEnvironmentConfig
    {
        private IBaseUrls _baseUrls;
        private string _baseUrl;
        private Environment? _environment;

        private readonly XPathNavigator _nav;
        private readonly IEnvironmentConfig _template;

        public EnvironmentConfig(XPathNavigator nav, IEnvironmentConfig template)
        {
            _template = template;

            if (_template != null)
            {
                _baseUrl = _template.BaseUrl;
                _environment = template.Environment;
            }

            _nav = nav;
        }

        public IBaseUrls BaseUrls
        {
            get { return _baseUrls ?? (_baseUrls = new BaseUrls(_nav.Select("baseUrls"), _template != null ? _template.BaseUrls : null)); }
        }

        public string BaseUrl
        {
            get { return _baseUrl ?? (_baseUrl = BaseUrls.BaseUrlMap.Single(p => p.Key.Equals(Environment.ToString(), System.StringComparison.Ordinal)).Value); }
        }

        public Environment Environment
        {
            get
            {
                if (_environment.HasValue)
                    return _environment.Value;

                var envSetting = ConfigurationManager.AppSettings["environment"];

                if (envSetting.Equals(PTO.Core.Enums.Environment.Prod.ToString()))
                    _environment = PTO.Core.Enums.Environment.Prod;

                if (envSetting.Equals(PTO.Core.Enums.Environment.QA.ToString()))
                    _environment = PTO.Core.Enums.Environment.QA;

                if (envSetting.Equals(PTO.Core.Enums.Environment.Int.ToString()))
                    _environment = PTO.Core.Enums.Environment.Int;

                _environment = PTO.Core.Enums.Environment.Dev;

                return _environment.Value;
            }
        }
    }

    public class BaseUrls : IBaseUrls
    {
        readonly Mapping _baseUrlsMapping;

        public BaseUrls(XPathNodeIterator iter, IBaseUrls template)
        {
            var baseUrlsMapping = new Mapping(template != null ? template.BaseUrlMap : null);

            if (iter.MoveNext())
            {
                baseUrlsMapping.Init(iter.Current.Select("baseUrl"));
            }

            _baseUrlsMapping = baseUrlsMapping;
        }

        public IDictionary<string, string> BaseUrlMap
        {
            get { return _baseUrlsMapping; }
        }
    }
}
