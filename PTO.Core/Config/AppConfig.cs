using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.Xml.XPath;

namespace PTO.Core.Config
{
    public sealed class AppConfigData
    {
        private readonly XPathDocument _configDoc;
        private readonly AppConfigData _template;

        private static XmlElement _section;

        private IApplicationConfig _application;
        private IConstantsConfig _constants;
        private IEncryptionConfig _encryption;
        private IEmailConfig _email;
        private IUserConfig _user;
        private IEnvironmentConfig _environment;

        public AppConfigData(XmlNode section)
        {
            _section = section as XmlElement;
            XmlNodeReader xnr = new XmlNodeReader(section);

            _configDoc = new XPathDocument(xnr);
            _template = new AppConfigData();

            xnr.Close();
        }

        public AppConfigData()
        {
            XmlDocument doc = new XmlDocument();
            HttpContext context = HttpContext.Current;
            string path = string.Empty;
            XPathNavigator nav = null;

            string configFilePath = WebConfigurationManager.AppSettings["ConfigFilePath"];

            // check AppSettings for specified config path
            if (!string.IsNullOrEmpty(configFilePath))
            {
                path = configFilePath;

                // see if you can find it
                if (!File.Exists(path))
                {
                    if (context != null && context.Request.PhysicalApplicationPath != null)
                    {
                        path = Path.Combine(context.Request.PhysicalApplicationPath, @"bin\", path);
                    }
                    else
                    {
                        path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                    }
                }
            }

            if (!File.Exists(path))
            {
                if (context != null && context.Request.PhysicalApplicationPath != null)
                {
                    path = Path.Combine(context.Request.PhysicalApplicationPath, @"bin\PTO.config");
                }
                else
                {
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"PTO.config");
                }
            }

            if (File.Exists(path))
            {
                doc.Load(path);

                if (doc.DocumentElement != null)
                {
                    nav = doc.DocumentElement.CreateNavigator();
                }
            }
            else
            {
                if (_section != null)
                {
                    XmlNode importedSection = doc.ImportNode(_section, true);
                    doc.AppendChild(importedSection);
                }
                else
                {
                    doc.AppendChild(doc.CreateElement("dummy"));
                }

                if (doc.DocumentElement != null)
                {
                    XmlNodeReader xnr = new XmlNodeReader(doc.DocumentElement);

                    _configDoc = new XPathDocument(xnr);

                    xnr.Close();
                    nav = _configDoc.CreateNavigator();
                }
            }

            GetConfig(nav);
        }

        private void GetConfig(XPathNavigator nav)
        {
            _application = new ApplicationConfig(GetChild(nav, "application"), null);
            _constants = new ConstantsConfig(GetChild(nav, "constants"), null);
            _encryption = new EncryptionConfig(GetChild(nav, "encryption"), null);
            _email = new EmailConfig(GetChild(nav, "email"), null);
            _user = new UserConfig(GetChild(nav, "user"), null);
            _environment = new EnvironmentConfig(GetChild(nav, "environment"), null);
        }

        private XPathNavigator GetChild(string nodeName)
        {
            return GetChild(_configDoc.CreateNavigator(), nodeName);
        }

        private XPathNavigator GetChild(XPathNavigator nav, string nodeName)
        {
            XPathNodeIterator iter = nav.Select("/*/" + nodeName);

            if (iter.MoveNext())
            {
                return iter.Current;
            }

            // this isn't the right node -- so the sub-queries will all fail
            return nav;
        }

        public IApplicationConfig Application
        {
            get { return _application ?? (_application = new ApplicationConfig(GetChild("application"), _template != null ? _template.Application : null)); }
        }

        public IConstantsConfig Constants
        {
            get { return _constants ?? (_constants = new ConstantsConfig(GetChild("constants"), _template != null ? _template.Constants : null)); }
        }

        public IEncryptionConfig Encryption
        {
            get { return _encryption ?? (_encryption = new EncryptionConfig(GetChild("encryption"), _template != null ? _template.Encryption : null)); }
        }

        public IEmailConfig Email
        {
            get { return _email ?? (_email = new EmailConfig(GetChild("email"), _template != null ? _template.Email : null)); }
        }

        public IUserConfig User
        {
            get { return _user ?? (_user = new UserConfig(GetChild("user"), _template != null ? _template.User : null)); }
        }

        public IEnvironmentConfig Environment
        {
            get { return _environment ?? (_environment = new EnvironmentConfig(GetChild("environment"), _template != null ? _template.Environment : null)); }
        }
    }

    public class AssemblyClass : IAssemblyClass
    {
        private readonly string _dll;
        private readonly string _class;

        public AssemblyClass(XPathNodeIterator iter, IAssemblyClass template)
        {
            if (template != null)
            {
                _dll = template.Dll;
                _class = template.Class;
            }

            if (iter.MoveNext())
            {
                _dll = iter.Current.GetAttribute("dll", string.Empty);
                _class = iter.Current.GetAttribute("class", string.Empty);
            }
        }

        public string Dll
        {
            get { return _dll; }
        }

        public string Class
        {
            get { return _class; }
        }
    }

    public class Mapping : IdValueDictionary
    {
        public Mapping(IEnumerable<KeyValuePair<string, string>> dictionary)
            : base(dictionary)
        {
        }
    }
}
