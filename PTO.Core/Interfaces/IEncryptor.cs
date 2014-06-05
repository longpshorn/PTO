using PTO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Core.Interfaces
{
    public interface IEncryptor
    {
        string GenerateSalt();
        string GenerateSalt(int workFactor);

        string HashPassword(string input);
        string HashPassword(string input, int workFactor);
        string HashPassword(string input, string salt);

        bool Verify(string text, string hash);
        bool VerifyHashAndShift(string text, string salt, string hash, ShiftDirection shiftDirection, int shiftFactor, int shiftOffset, bool killSalt);

        string HashAndShift(string input, string salt, ShiftDirection shiftDirection, int shiftFactor, int shiftOffset, bool killSalt);
    }
}
