using System.ComponentModel;

namespace PTO.Core.Email
{
    public enum EmailSourceType
    {
        [Description("Email type which uses a template based on an PTO Entity model")]
        EntityEmail
    }
}