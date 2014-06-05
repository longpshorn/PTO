using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using PTO.Entity.Email;
using EntityEmail = PTO.Entity.Email.Email;
using NetClient = System.Net.Mail.SmtpClient;

namespace PTO.Email.Client
{
    public class SmtpClient : ISmtpClient
    {
        #region Fields
        private readonly NetClient _netClient;
        #endregion

        #region Constuctor
        public SmtpClient(ISmtpClientConfig config)
        {
            Config = config;

            _netClient = new NetClient {
                Credentials = new NetworkCredential(Config.Username, Config.Password),
                Host = Config.Server,
                Port = Config.Port
            };
        }
        #endregion

        #region Properties
        protected internal ISmtpClientConfig Config { get; private set; }
        #endregion

        #region ISmtpClient Members
        public virtual EmailSendStatus SendEmail(EntityEmail email)
        {
            var message = new MailMessage {
                From = new MailAddress(email.FromAddress),
                Body = email.TextBody,
                Subject = email.Subject,
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8
            };

            var recipients = email.IsSolicited
                ? email.Recipients.ToList()
                : email.Recipients.Where(x => !x.IsUnsubscribed).ToList();

            //It's possible that all the recipients could be unsubscribed,
            //in which case there's nobody to send to
            bool hasValidRecipients = recipients.Any();

            foreach (Recipient recipient in recipients)
            {
                switch (recipient.Type)
                {
                    case RecipientType.To:
                        message.To.Add(recipient.Address);
                        break;
                    case RecipientType.Cc:
                        message.CC.Add(recipient.Address);
                        break;
                    case RecipientType.Bcc:
                        message.Bcc.Add(recipient.Address);
                        break;
                }
            }

            AlternateView alternate = AlternateView.CreateAlternateViewFromString(email.HtmlBody, null, MediaTypeNames.Text.Html);

            message.AlternateViews.Add(alternate);

            if (hasValidRecipients)
            {
                _netClient.Send(message);

                IEnumerable<MailAddress> sendees = message.To.Union(message.CC).Union(message.Bcc).ToList();
                foreach (var recipient in email.Recipients)
                {
                    if (sendees.Any(y => y.Address.Equals(recipient.Address, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        recipient.SendStatus = RecipientSendStatus.Sent;
                    }
                    else
                    {
                        recipient.SendStatus = RecipientSendStatus.NotSentUnsubscribed;
                    }
                }

                return EmailSendStatus.Sent;
            }

            return EmailSendStatus.NoValidRecipients;
        }
        #endregion
    }
}