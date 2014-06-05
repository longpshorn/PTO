using PTO.Core.Enums;
using PTO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Core.Encryption
{
    public abstract class EncryptorBase : IEncryptor
    {
        public virtual string GenerateSalt()
        {
            throw new NotImplementedException();
        }

        public virtual string GenerateSalt(int workFactor)
        {
            throw new NotImplementedException();
        }

        public virtual string HashPassword(string input)
        {
            throw new NotImplementedException();
        }

        public virtual string HashPassword(string input, int workFactor)
        {
            throw new NotImplementedException();
        }

        public virtual string HashPassword(string input, string salt)
        {
            throw new NotImplementedException();
        }

        public virtual bool Verify(string text, string hash)
        {
            throw new NotImplementedException();
        }

        public virtual bool VerifyHashAndShift(string text, string salt, string hash, ShiftDirection shiftDirection, int shiftFactor, int shiftOffset, bool killSalt)
        {
            return HashAndShift(text, salt, shiftDirection, shiftFactor, shiftOffset, killSalt) == hash;
        }

        public virtual string HashAndShift(string input, string salt, ShiftDirection shiftDirection, int shiftFactor, int shiftOffset, bool killSalt)
        {
            byte[] shiftedBytes;
            var hashedPassword = HashPassword(input, salt);

            if (killSalt)
            {
                hashedPassword = hashedPassword.TrimStart(salt.ToCharArray());
            }

            var passwordBytes = Encoding.UTF8.GetBytes(hashedPassword);
            var byteToShift = GetByteToShift(passwordBytes, shiftOffset, shiftDirection);

            switch (shiftDirection)
            {
                case ShiftDirection.Right:
                    shiftedBytes = ShiftRight(passwordBytes, byteToShift, shiftFactor);
                    break;
                default:
                    shiftedBytes = ShiftLeft(passwordBytes, byteToShift, shiftFactor);
                    break;
            }

            return Encoding.UTF8.GetString(shiftedBytes);
        }

        private int GetByteToShift(byte[] passwordBytes, int shiftOffset, ShiftDirection shiftDirection)
        {
            var byteToShift = 0;
            var bytesLength = passwordBytes.Length;

            shiftOffset = Math.Abs(shiftOffset);

            if (shiftOffset > bytesLength)
            {
                if (shiftDirection == ShiftDirection.Left)
                {
                    byteToShift = bytesLength - 1;
                }
            }
            else
            {
                if (shiftDirection == ShiftDirection.Left)
                {
                    byteToShift = shiftOffset - 1;
                }
                else
                {
                    byteToShift = bytesLength - shiftOffset;
                }
            }

            return byteToShift;
        }

        private byte[] ShiftLeft(byte[] bytes, int byteToShift, int shiftFactor)
        {
            bytes[byteToShift] = (byte)(bytes[byteToShift] << shiftFactor);
            return bytes;
        }

        private byte[] ShiftRight(byte[] bytes, int byteToShift, int shiftFactor)
        {
            bytes[byteToShift] = (byte)(bytes[byteToShift] >> shiftFactor);
            return bytes;
        }
    }
}
