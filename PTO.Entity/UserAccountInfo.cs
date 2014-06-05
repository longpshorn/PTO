using PTO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity
{
    public class UserAccountInfo : AuditEntity<UserAccountInfo, int>
    {
        public UserAccountInfo()
            : base()
        {
        }

        public string LoginEmail { get; set; }

        public bool IsValidLoginEmail { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int LoginCount { get; set; }

        public virtual User User { get; set; }
    }
}
