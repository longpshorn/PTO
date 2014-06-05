using System.Collections.Generic;
using System.Xml.XPath;
using PTO.Core.Extensions;

namespace PTO.Core.Config
{
    public class EmailConfig : IEmailConfig
    {
        private string _fromAddress;
        private IEmailSMTP _smtp;
        private IEmailToAddresses _toAddresses;

        private readonly XPathNavigator _nav;
        private readonly IEmailConfig _template;

        public EmailConfig(XPathNavigator nav, IEmailConfig template)
        {
            _template = template;

            if (_template != null)
            {
                _fromAddress = _template.FromAddress;
            }

            SetFromAddress(nav);

            _nav = nav;
        }

        public string FromAddress
        {
            get { return _fromAddress; }
        }

        public IEmailToAddresses ToAddresses
        {
            get { return _toAddresses ?? (_toAddresses = new EmailToAddresses(_nav.Select("toAddresses"), _template != null ? _template.ToAddresses : null)); }
        }

        public IEmailSMTP SMTP
        {
            get { return _smtp ?? (_smtp = new EmailSMTP(_nav.Select("smtp"), _template != null ? _template.SMTP : null)); }
        }

        private void SetFromAddress(XPathNavigator nav)
        {
            var value = nav.GetAttribute("fromAddress", string.Empty);

            if (value.HasValue())
                _fromAddress = value;
        }
    }

    public class EmailToAddresses : IEmailToAddresses
    {
        readonly Mapping _addressesMapping;

        public EmailToAddresses(XPathNodeIterator iter, IEmailToAddresses template)
        {
            var addressesMapping = new Mapping(template != null ? template.ToAddressesMap : null);

            if (iter.MoveNext())
            {
                addressesMapping.Init(iter.Current.Select("toAddress"));
            }

            _addressesMapping = addressesMapping;
        }

        public IDictionary<string, string> ToAddressesMap
        {
            get
            {
                return _addressesMapping;
            }
        }
    }

    public class EmailSMTP : IEmailSMTP
    {
        private readonly string _server;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;

        public EmailSMTP(XPathNodeIterator iter, IEmailSMTP template)
        {
            if (template != null)
            {
                _server = template.Server;
                _port = template.Port;
                _username = template.Username;
                _password = template.Password;
            }

            if (iter.MoveNext())
            {
                _server = iter.Current.GetAttribute("server", string.Empty);
                _port = int.Parse(iter.Current.GetAttribute("port", string.Empty));
                _username = iter.Current.GetAttribute("username", string.Empty);
                _password = iter.Current.GetAttribute("password", string.Empty);
            }
        }

        public string Server
        {
            get { return _server; }
        }

        public int Port
        {
            get { return _port; }
        }

        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}
