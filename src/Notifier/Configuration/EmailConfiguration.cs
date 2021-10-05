using Notifier.Contracts;
using Notifier.Models;

namespace Notifier.Configuration
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public SmtpPort Port { get; }

        public EmailAddress FromAddress { get; }

        public EmailAddress ToAddress { get; }

        public User User { get; }

        public Password Password { get; }

        public EmailConfiguration()
        {
            Port = SmtpPort.Create(2525);
            FromAddress = EmailAddress.Create("some@domain.com");
            ToAddress = EmailAddress.Create("other@domain.com");
            User = User.Create("someone");
            Password = Password.Create("5up3r53cur3");
        }

        public override string ToString() =>
            $"Port: {Port} - From: {FromAddress} - To: {ToAddress} - Credentials: [{User}:{Password}]";
    }
}
