using System.ComponentModel.DataAnnotations;
using PTO.Core.Entities;

namespace PTO.Entity.Email
{
    public class Recipient : AuditEntity<Recipient, int>
    {
        public Recipient()
        {
            Type = RecipientType.To;
            SendStatus = RecipientSendStatus.Pending;
        }

        public Recipient(Email email, string address)
            : this()
        {
            Email = email;
            Address = address;
            SendStatus = RecipientSendStatus.Pending;
        }

        [Required]
        public virtual Email Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        public virtual RecipientType Type { get; set; }

        //Not a persistent property
        public bool IsUnsubscribed { get; set; }

        [Required]
        public virtual RecipientSendStatus SendStatus { get; set; }
    }
}
