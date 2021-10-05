using Notifier.Models;

namespace Notifier.Contracts
{
    public interface IEmailConfiguration
    {
        SmtpPort Port { get; }

        EmailAddress FromAddress { get; }

        EmailAddress ToAddress { get; }

        User User { get; }

        Password Password { get; }
    }
}
