using PTO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity
{
    public class UserLogin : AuditEntity<UserLogin, int>
    {
        public UserLogin()
            : base()
        {
        }

        public int LoginAttemptCount { get; set; }

        public string IpAddress { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }

        public virtual User User { get; set; }
    }
}
