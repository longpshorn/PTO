using PTO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTO.Core
{
    public class SessionUser : IPrincipal, IIdentity
    {
        // User database properties
        public int Id { get; set; }

        public UserType UserType { get; set; }

        public string LoginEmail { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int LoginCount { get; set; }

        public bool IsActive { get; set; }

        // User model computed properties
        public string DisplayName { get; set; }

        // SessionUser-specific properties
        public bool IsPersistentLogin { get; set; }

        public static SessionUser Current
        {
            get { return Thread.CurrentPrincipal as SessionUser; }
        }

        #region IPrincipal Members
        public IIdentity Identity { get { return this; } }

        public bool IsInRole(string role) { throw new NotImplementedException(); }
        #endregion

        #region IIdentity Members
        public bool IsAuthenticated { get; set; }

        public string AuthenticationType
        {
            //TODO - this should be configurable, but we don't really care about it at this point
            get { return "Forms"; }
        }

        public string Name
        {
            get { return UserName; }
        }
        #endregion

        public static void SetCurrent(SessionUser user)
        {
            Thread.CurrentPrincipal = user;
        }
    }
}
