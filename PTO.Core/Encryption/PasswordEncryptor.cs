using PTO.Core.Config;
using PTO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Core.Encryption
{
    public class PasswordEncryptor : IPasswordEncryptor
    {
        private readonly IEncryptor _encryptor;

        public PasswordEncryptor(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public PasswordEncryptionContext EncryptPassword(string password)
        {
            string salt = GetCurrentSalt();

            var request = new PasswordEncryptionContext(password, salt);
            return EncryptPassword(request);
        }

        public bool Verify(PasswordEncryptionContext request, string hash)
        {
            return EncryptPassword(request).EncryptedPassword.Equals(hash);
        }

        private string GetCurrentSalt()
        {
            return _encryptor.GenerateSalt(AppConfig.Current.Encryption.WorkFactor);
        }

        private PasswordEncryptionContext EncryptPassword(PasswordEncryptionContext request)
        {
            string val = _encryptor.HashAndShift(
                request.EncryptedPassword,
                request.Salt,
                AppConfig.Current.Encryption.ShiftDirection,
                AppConfig.Current.Encryption.ShiftFactor,
                AppConfig.Current.Encryption.ShiftOffset,
                true
            );

            return new PasswordEncryptionContext(val, request.Salt);
        }
    }
}
