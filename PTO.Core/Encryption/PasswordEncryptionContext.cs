using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Core.Encryption
{
    public struct PasswordEncryptionContext
    {
        private readonly string _password;
        private readonly string _salt;

        public PasswordEncryptionContext(string password, string salt)
        {
            _password = password;
            _salt = salt;
        }

        public string EncryptedPassword
        {
            get { return _password; }
        }

        public string Salt
        {
            get { return _salt; }
        }
    }
}
