using PTO.Core.Entities;
using PTO.Core.Enums;

namespace PTO.Entity
{
    public class UserEmail : AuditEntity<UserEmail, int>
    {
        public UserEmail()
            : base()
        {
            Type = EmailType.Personal;
            IsPrimary = true;
            IsActive = true;
        }

        public string Address { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsActive { get; set; }

        public EmailType Type { get; set; }

        public virtual User User { get; set; }
    }
}
