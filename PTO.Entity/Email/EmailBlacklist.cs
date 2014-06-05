using PTO.Core.Entities;

namespace PTO.Entity.Email
{
    public class EmailBlacklist : AuditEntity<EmailBlacklist, int>
    {
        protected EmailBlacklist() { }

        public EmailBlacklist(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public string EmailAddress { get; set; }
    }
}
