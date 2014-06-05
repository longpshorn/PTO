using System.ComponentModel;

namespace PTO.Entity.Email
{
    public enum RecipientSendStatus
    {
        Pending = 1,

        Sent = 2,

        [Description("Not Sent - Recipient Email Unsubscribed")]
        NotSentUnsubscribed = 3
    }
}
