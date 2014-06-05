using PTO.Core.Config;

namespace PTO.Email.Client
{
    public class DefaultSmtpClientConfig : ISmtpClientConfig
    {
        // ReSharper disable InconsistentNaming
        private static readonly string _server;
        private static readonly int _port;
        private static readonly string _userName;
        private static readonly string _password;
        // ReSharper restore InconsistentNaming

        static DefaultSmtpClientConfig()
        {
            _server = AppConfig.Current.Email.SMTP.Server;
            _port = AppConfig.Current.Email.SMTP.Port;
            _userName = AppConfig.Current.Email.SMTP.Username;
            _password = AppConfig.Current.Email.SMTP.Password;
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
            get { return _userName; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}
