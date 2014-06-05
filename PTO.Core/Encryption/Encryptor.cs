using PTO.Core.Interfaces;
using BCN = BCrypt.Net.BCrypt;

namespace PTO.Core.Encryption
{
    public class Encryptor : EncryptorBase, IEncryptor
    {
        public override string GenerateSalt()
        {
            return BCN.GenerateSalt();
        }

        public override string GenerateSalt(int workFactor)
        {
            return BCN.GenerateSalt(workFactor);
        }

        public override string HashPassword(string input)
        {
            return BCN.HashPassword(input);
        }

        public override string HashPassword(string input, int workFactor)
        {
            return BCN.HashPassword(input, workFactor);
        }

        public override string HashPassword(string input, string salt)
        {
            return BCN.HashPassword(input, salt);
        }

        public override bool Verify(string text, string hash)
        {
            return BCN.Verify(text, hash);
        }
    }
}
