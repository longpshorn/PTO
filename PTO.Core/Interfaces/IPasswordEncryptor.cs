using PTO.Core.Encryption;

namespace PTO.Core.Interfaces
{
    public interface IPasswordEncryptor
    {
        PasswordEncryptionContext EncryptPassword(string password);
        bool Verify(PasswordEncryptionContext request, string hash);
    }
}
