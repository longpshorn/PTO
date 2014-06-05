using PTO.Entity.Email;
using EntityEmail = PTO.Entity.Email.Email;

namespace PTO.Email.Client
{
    public interface ISmtpClient
    {
        EmailSendStatus SendEmail(EntityEmail email);
    }
}
