namespace PTO.Email.Client
{
    public interface ISmtpClientConfig
    {
        string Server { get; }
        int Port { get; }
        string Username { get; }
        string Password { get; }
    }
}
