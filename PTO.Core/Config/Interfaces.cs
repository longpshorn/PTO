using PTO.Core.Enums;
using System.Collections.Generic;

namespace PTO.Core.Config
{
    public interface IAppConfiguration
    {
        IApplicationConfig Application { get; }
        IConstantsConfig Constants { get; set; }
        IEmailConfig Email { get; }
        IUserConfig User { get; }
    }

    public interface IApplicationConfig
    {
        int CacheExpiry { get; }
        int LoginExpiry { get; }
        int PersistentCookieExpiryDays { get; }
        string DynamicFileDirectory { get; }
        IApplicationData Data { get; }
    }

    public interface IApplicationData
    {
        bool AutomaticValidateOnSaveEnabled { get; }
    }

    public interface IConstantsConfig
    {
        int MinimumYear { get; }
        int RegistrationWindowDays { get; }
        string GoogleMapsApiKey { get; }
    }

    public interface IEncryptionConfig
    {
        int WorkFactor { get; }
        int ShiftFactor { get; }
        int ShiftOffset { get; }
        ShiftDirection ShiftDirection { get; }
    }

    public interface IEmailConfig
    {
        string FromAddress { get; }
        IEmailToAddresses ToAddresses { get; }
        IEmailSMTP SMTP { get; }
    }

    public interface IEmailToAddresses
    {
        IDictionary<string, string> ToAddressesMap { get; }
    }

    public interface IEmailSMTP
    {
        string Server { get; }
        int Port { get; }
        string Username { get; }
        string Password { get; }
    }

    public interface IUserConfig
    {
        string DefaultImage { get; }
    }

    public interface IEnvironmentConfig
    {
        IBaseUrls BaseUrls { get; }
        string BaseUrl { get; }
        Environment Environment { get; }
    }

    public interface IAssemblyClass
    {
        string Dll { get; }
        string Class { get; }
    }

    public interface IBaseUrls
    {
        IDictionary<string, string> BaseUrlMap { get; }
    }
}
