using System.ComponentModel.DataAnnotations;
using PTO.Core.Entities;

namespace PTO.Entity.Email
{
    public class EmailUnsubscribed : AuditEntity<EmailUnsubscribed, int>
    {
        protected EmailUnsubscribed() { }

        public EmailUnsubscribed(Recipient recipient, string description)
        {
            EmailUnsubscribedFrom = recipient.Email;
            EmailAddress = recipient.Address;
            Description = description;
        }

        [Required]
        public virtual Email EmailUnsubscribedFrom { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        [StringLength(200)]
        public string EmailAddress { get; set; }
    }

    public enum EmailUnsubscribeResult
    {
        Success,
        AlreadyUnsubscribed,
        GeneralFailure,
        InvalidEmail
    }
}