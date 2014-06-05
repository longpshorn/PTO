using PTO.Core.Entities;
using PTO.Core.Enums;

namespace PTO.Entity
{
    public class UserPhone : AuditEntity<UserPhone, int>
    {
        public UserPhone()
            : base()
        {
            Type = PhoneType.Cell;
            IsPrimary = true;
            IsActive = true;
        }

        public string Number { get; set; }

        public string Extension { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsActive { get; set; }

        public PhoneType Type { get; set; }

        public virtual User User { get; set; }
    }
}
