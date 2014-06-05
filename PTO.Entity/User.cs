using PTO.Core.Encryption;
using PTO.Core.Entities;
using PTO.Core.Enums;
using PTO.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace PTO.Entity
{
    public class User : AuditEntity<User, int>
    {
        public User()
            : base()
        {
            UserType = UserType.Parent;

            Logins = new List<UserLogin>();
            Relationships = new List<Relationship>();

            Addresses = new List<UserAddress>();
            Emails = new List<UserEmail>();
            Phones = new List<UserPhone>();

            IsActive = true;
        }

        public UserType UserType { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public bool IsAuthenticated { get; set; }

        public bool IsActive { get; set; }

        public virtual UserAccountInfo AccountInfo { get; set; }

        public virtual ICollection<UserLogin> Logins { get; set; }

        public virtual ICollection<Relationship> Relationships { get; set; }

        public virtual ICollection<UserAddress> Addresses { get; set; }

        public virtual ICollection<UserEmail> Emails { get; set; }

        public virtual ICollection<UserPhone> Phones { get; set; }

        public string DisplayName
        {
            get
            {
                string format = string.IsNullOrEmpty(MiddleName) ? "{0} {1}" : "{0} {2} {1}";
                return string.Format(format, FirstName, LastName, MiddleName);
            }
        }

        public void CompleteRegistration()
        {
            AccountInfo.IsValidLoginEmail = true;
        }

        public User Authenticate(string password, IPasswordEncryptor encryptor)
        {
            var context = new PasswordEncryptionContext(password, AccountInfo.Salt);
            IsAuthenticated = encryptor.Verify(context, AccountInfo.Password);
            return this;
        }

        public void UpdateLoginInformation()
        {
            AccountInfo.LastLoginDate = DateTime.Now;
            AccountInfo.LoginCount++;
        }
    }
}
